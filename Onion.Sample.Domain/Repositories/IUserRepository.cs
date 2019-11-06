using Onion.Sample.Domain.Entities;
using Onion.Sample.Domain.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onion.Sample.Domain.Repositories
{
	public interface IUserRepository : IRepository<ApplicationUser, UserQuery>
	{
		Task DeleteLoginsRangeAsync(IEnumerable<UserLogin> entity);
		Task<IEnumerable<UserLogin>> QueryLoginsAsync(UserLoginQuery query);
		Task AddLoginAsync(UserLogin entity);
		Task AddRolesAsync(ApplicationUser user,params Role[] roles);
	}
}
