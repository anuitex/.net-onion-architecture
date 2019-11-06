using Onion.Sample.Domain.Entities;
using Onion.Sample.Domain.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onion.Sample.Infrastructure
{
	public class MemoryRepository<EntityType, QueryType>
		where QueryType : BaseQuery
		where EntityType : Entity
	{
		protected static List<EntityType> entities = new List<EntityType>();

		public async Task<IEnumerable<EntityType>> QueryAsync(QueryType query)
		{
			return await Task.FromResult(entities);
		}

		public async Task CreateAsync(EntityType entity)
		{
			entities.Add(entity);
		}

		public async Task UpdateAsync(EntityType entity)
		{
			var index = entities.FindIndex(x=>x.Id == entity.Id);
			entities[index] = entity;
		}

		public async Task DeleteAsync(EntityType entity)
		{
			entities.Remove(entity);
		}

		public async Task DeleteAsync(long id)
		{
			entities.RemoveAll(x => x.Id == id);
		}
	}
}
