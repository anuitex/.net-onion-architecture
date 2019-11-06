using Onion.Sample.Domain.Common;
using Onion.Sample.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Onion.Sample.Infrastructure.Common
{
	public class FlightFabric : IFlightFabric
	{
		public Task<IFlightPackageRepository> CreateInstanceAsync(FlightApiType hotelApiType)
		{
			throw new NotImplementedException();
		}
	}
}
