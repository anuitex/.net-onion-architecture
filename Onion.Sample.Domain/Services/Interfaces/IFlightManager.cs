using System.Collections.Generic;
using System.Threading.Tasks;
using Onion.Sample.Domain.Common;
using Onion.Sample.Domain.Repositories.Models;

namespace Onion.Sample.Domain.Services
{
	public interface IFlightManager
	{
		Task<IEnumerable<FlightPackageModel>> QueryAsync(FlightApiType flightApiType, FlightQuery flightQuery);
	}
}