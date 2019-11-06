using Onion.Sample.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Onion.Sample.Domain.Repositories.Models
{
	public class FlightQuery : BaseQuery
	{
		public DateTime DateFrom { get; private set; }
		public DateTime DateTo { get; private set; }
		public decimal PriceFrom { get; private set; }
		public decimal PriceTo { get; private set; }
		public IEnumerable<FlightType> FlightTypes { get; private set; }

		public FlightQuery(DateTime dateFrom, DateTime dateTo, decimal priceFrom, decimal priceTo, IEnumerable<FlightType> flightTypes)
		{
			DateFrom = dateFrom;
			DateTo = dateTo;
			PriceFrom = priceFrom;
			PriceTo = priceTo;
			FlightTypes = flightTypes;
		}
	}
}
