using Onion.Sample.Domain.Entities;
using System.Collections.Generic;

namespace Onion.Sample.Domain.Repositories.Models
{
	public class FlightPackageModel
	{
		public FlightPackage FlightPackage { get; private set; }
		public IEnumerable<FlightPrice> FlightPrices { get; private set; }
		public IEnumerable<FlightTax> Taxes { get; private set; }

		public FlightPackageModel(FlightPackage flightPackage, IEnumerable<FlightPrice> flightPrice, IEnumerable<FlightTax> taxes)
		{
			FlightPackage = flightPackage;
			FlightPrices = flightPrice;
			Taxes = taxes;
		}
	}
}
