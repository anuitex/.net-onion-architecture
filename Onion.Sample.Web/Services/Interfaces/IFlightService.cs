using System.Collections.Generic;
using System.Threading.Tasks;
using Onion.Sample.Domain.Repositories.Models;

namespace Onion.Sample.Application.Services
{
	public interface IFlightService
	{
		Task<IEnumerable<FlightPackageModel>> QueryAsync(FlightQuery flightQuery);
	}
}