using System.Threading.Tasks;
using Onion.Sample.Domain.Entities;

namespace Onion.Sample.Domain.Services
{
	public interface IUserManager
	{
		Task SetRolesAsync(ApplicationUser user, params Role[] roles);
		Task<ApplicationUser> SignInInAsync(string email, string password, int retryCount = 3, bool isLocked = true);
		Task SignUpAsync(ApplicationUser user);
	}
}