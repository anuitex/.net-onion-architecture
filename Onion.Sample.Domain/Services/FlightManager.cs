using Onion.Sample.Domain.Common;
using Onion.Sample.Domain.Repositories;
using Onion.Sample.Domain.Repositories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Sample.Domain.Services
{
	public class FlightManager : IFlightManager
	{
		private readonly IFlightPackageRepository _flightPackageRepository;
		private readonly IFlightTaxRepository _flightTaxRepository;
		private readonly IFlightPriceRepository _flightPriceRepository;
		private readonly IFlightFabric _flightFabric;

		public FlightManager(IFlightPackageRepository flightPackageRepository, IFlightFabric flightFabric,
			IFlightTaxRepository flightTaxRepository, IFlightPriceRepository flightPriceRepository)
		{
			_flightPackageRepository = flightPackageRepository;
			_flightFabric = flightFabric;
			_flightTaxRepository = flightTaxRepository;
			_flightPriceRepository = flightPriceRepository;
		}

		public async Task<IEnumerable<FlightPackageModel>> QueryAsync(FlightApiType flightApiType, FlightQuery flightQuery)
		{
			using (var flightPackageRepository = await _flightFabric.CreateInstanceAsync(flightApiType))
			{
				var flights = await flightPackageRepository.QueryAsync(flightQuery);
				var flightPrices = await _flightPriceRepository.QueryAsync(new FlightPriceQuery(flights.SelectMany(flight => flight.Flights)
					.Select(flight => flight.Id)));
				var locations = flights.SelectMany(x => x.Flights)
					.Select(flight => new FlightTaxQueryItem(flight.LocationFromId, flight.LocationToId));
				var taxes = await _flightTaxRepository.QueryAsync(new FlightTaxQuery(locations));
				//TODO: Calculate tax
				var flightPackages =  flights.Select(flight => new FlightPackageModel(flight,
					flightPrices.Where(flightPrice=>flightPrice.FlightId == flight.Id),
					taxes
					));
				return flightPackages;
			}
		}
	}
}
