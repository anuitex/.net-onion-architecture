using Onion.Sample.Domain.Entities;

namespace Onion.Sample.Application.ViewModels
{
	public class RoleView
	{
		public string Name { get; private set; }

		public RoleView(Role role)
		{
			Name = role.Name;
		}
	}
}
