using Onion.Sample.Domain.Entities;
using Onion.Sample.Domain.Repositories;
using Onion.Sample.Domain.Repositories.Models;

namespace Onion.Sample.Infrastructure.Repositories
{
	public class HotelRepository : MemoryRepository<Hotel, HotelQuery>,IHotelRepostiory
	{
		public void Dispose()
		{
			throw new System.NotImplementedException();
		}
	}
}
