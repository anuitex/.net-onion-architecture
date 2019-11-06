using System.Collections.Generic;
using System.Threading.Tasks;
using Onion.Sample.Domain.Common;
using Onion.Sample.Domain.Repositories.Models;

namespace Onion.Sample.Domain.Services
{
	public interface IHotelManager
	{
		Task<IEnumerable<HotelModel>> QueryAsync(HotelApiType hotelApiType, HotelQuery hotelQueryModel);
	}
}