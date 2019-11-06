using Onion.Sample.Domain.Repositories;
using System.Threading.Tasks;

namespace Onion.Sample.Domain.Common
{
	public interface IHotelFabric
	{
		Task<IHotelRepostiory> CreateInstanceAsync(HotelApiType hotelApiType);
	}

	public enum HotelApiType
	{
		Sandals = 0,
		Stella = 1
	}
}
