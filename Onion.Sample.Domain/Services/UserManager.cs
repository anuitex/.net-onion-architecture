using Onion.Sample.Core;
using Onion.Sample.Domain.Entities;
using Onion.Sample.Domain.Repositories;
using Onion.Sample.Domain.Repositories.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Sample.Domain.Services
{
	public class UserManager : IUserManager
	{
		private IHashEncrypter _hashEncrypter;
		private IUserRepository _userRepository;
		private IUserLoginRepository _userLoginRepository;

		public UserManager(IHashEncrypter hashEncrypter, IUserRepository userRepository,
			IUserLoginRepository userLoginRepository)
		{
			_hashEncrypter = hashEncrypter;
			_userRepository = userRepository;
			_userLoginRepository = userLoginRepository;
		}

		public async Task<ApplicationUser> SignInInAsync(string email, string password, int retryCount = 3, bool isLocked = true)
		{
			ApplicationUser user;
			try
			{
				var users = await _userRepository.QueryAsync(new UserQuery(email)
				{
					PageSize = 1
				});
				var hashedPassword = _hashEncrypter.SHA512(password);
				user = users.SingleOrDefault(x => x.Email == email && password == hashedPassword);
				if (user is null && users.Any())
				{
					await CheckRetryLockAsync(users.FirstOrDefault(), retryCount, isLocked);
				}
				if (user is null)
				{
					throw new ValidationException("Invalid credentials!");
				}
				var logins = await _userRepository.QueryLoginsAsync(new UserLoginQuery(email));
				await _userRepository.DeleteLoginsRangeAsync(logins);
				return user;
			}
			catch (ArgumentNullException)
			{
				throw new ValidationException("Invalid credentials!");
			}
		}

		public async Task SignUpAsync(ApplicationUser user)
		{
			var existedUser = await _userRepository.QueryAsync(new UserQuery(user.Email));
			if (existedUser != null)
			{
				throw new ValidationException("User already exist!");
			}
			await _userRepository.CreateAsync(user);
		}

		public async Task SetRolesAsync(ApplicationUser user, params Role[] roles)
		{
			throw new NotImplementedException();
		}

		private async Task CheckRetryLockAsync(ApplicationUser user, int retryCount, bool isLocked)
		{
			if (!isLocked)
			{
				return;
			}
			if ((DateTime.UtcNow - user.LockedDate).Minutes < 15)
			{
				throw new ValidationException("Account has been locked, try again later!");
			}
			IEnumerable<UserLogin> logins = await _userLoginRepository.QueryAsync(new UserLoginQuery(user.Email));
			if (logins.Count() <= retryCount)
			{
				return;
			}
			user.Lock();
			await _userRepository.UpdateAsync(user);
			throw new ValidationException("Account has been locked, try again later!");
		}
	}
}
