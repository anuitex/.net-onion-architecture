using Onion.Sample.Domain.Entities;
using Onion.Sample.Domain.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onion.Sample.Domain.Repositories
{
	public interface IUserLoginRepository : IRepository<UserLogin, UserQuery>
	{
		Task DeleteRangeAsync(IEnumerable<UserLogin> entity);
		Task<IEnumerable<UserLogin>> QueryAsync(UserLoginQuery query);
		Task AddAsync(UserLogin entity);
	}
}
