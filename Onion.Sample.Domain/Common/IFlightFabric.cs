using Onion.Sample.Domain.Repositories;
using System.Threading.Tasks;

namespace Onion.Sample.Domain.Common
{
	public interface IFlightFabric
	{
		Task<IFlightPackageRepository> CreateInstanceAsync(FlightApiType hotelApiType);
	}

	public enum FlightApiType
	{
		Stella = 0,
		JetSet = 1
	}
}
