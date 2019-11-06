using System;
using System.ComponentModel.DataAnnotations;

namespace Onion.Sample.Domain.Entities
{
	public class ApplicationUser : Entity
	{
		public string Email { get; private set; }
		public string Name { get; private set; }
		public string Surname { get; private set; }
		public string PasswordHash { get; private set; }
		public bool IsEmailConfirmed { get; set; }
		public string SecurityStamp { get; private set; }
		public DateTime LockedDate { get; private set; }

		public ApplicationUser(string name, string surname, string passwordHash, bool isEmailConfirmed = false)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ValidationException("Name can't be empty or white space!");
			}
			if (string.IsNullOrWhiteSpace(surname))
			{
				throw new ValidationException("Name can't be empty or white space!");
			}
			var maxLength = 12;
			var minLength = 1;
			if (name.Length > maxLength || name.Length < minLength)
			{
				throw new ValidationException($"Name can't be less than {minLength} and more than {maxLength}!");
			}
			if (surname.Length > maxLength || surname.Length < minLength)
			{
				throw new ValidationException($"Surname can't be less than {minLength} and more than {maxLength}!");
			}
			Name = name;
			Surname = surname;
			if (string.IsNullOrWhiteSpace(passwordHash))
			{
				throw new ArgumentNullException(nameof(passwordHash));
			}
			PasswordHash = passwordHash;
		}

		public string GetFullName()
		{
			return $"{Name} {Surname}";
		}

		internal void Lock()
		{
			LockedDate = DateTime.UtcNow;
		}
	}
}
