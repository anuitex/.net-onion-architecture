using System.Collections.Generic;
using System.Threading.Tasks;
using Onion.Sample.Domain.Repositories.Models;

namespace Onion.Sample.Application.Services
{
	public interface IHotelService
	{
		Task<IEnumerable<HotelModel>> QueryAsync(HotelQuery hotelQuery);
	}
}