using Onion.Sample.Domain.Entities;
using Onion.Sample.Domain.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onion.Sample.Domain.Repositories
{
	public interface IRepository<EntityType, in QueryType> 
		where QueryType : BaseQuery
		where EntityType : Entity
	{
		Task<IEnumerable<EntityType>> QueryAsync(QueryType query);
		Task CreateAsync(EntityType entity);
		Task UpdateAsync(EntityType entity);
		Task DeleteAsync(EntityType entity);
		Task DeleteAsync(long id);
	}
}
