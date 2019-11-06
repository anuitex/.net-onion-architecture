using Onion.Sample.Domain.Entities;
using System.Collections.Generic;

namespace Onion.Sample.Application.Models
{
	public class UserSession
	{
		public readonly string Surname;
		public readonly string Name;
		public readonly string Email;
		public readonly IEnumerable<Role> Roles;

		public UserSession(ApplicationUser applicationUser, IEnumerable<Role> roles)
		{
			Surname = applicationUser.Surname;
			Name = applicationUser.Name;
			Email = applicationUser.Email;
			Roles = roles;
		}
	}
}
