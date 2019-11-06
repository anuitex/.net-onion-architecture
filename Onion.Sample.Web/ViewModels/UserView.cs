using Onion.Sample.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Onion.Sample.Application.ViewModels
{
	public class UserView
	{
		public readonly string Surname;
		public readonly string Name;
		public readonly string Email;
		public readonly IEnumerable<RoleView> Roles;

		public UserView(ApplicationUser applicationUser, IEnumerable<Role> roles)
		{
			Surname = applicationUser.Surname;
			Name = applicationUser.Name;
			Email = applicationUser.Email;
			var roleViews = roles.Select(role => new RoleView(role));
			Roles = roleViews;
		}
	}
}
