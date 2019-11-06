using Onion.Sample.Domain.Entities;
using Onion.Sample.Domain.Repositories.Models;
using System;
using System.Collections.Generic;

namespace Onion.Sample.Application.ViewModels.Flight
{
	public class FlightQueryView : FlightQuery
	{
		public FlightQueryView(DateTime dateFrom, DateTime dateTo, decimal priceFrom, decimal priceTo, IEnumerable<FlightType> flightTypes)
			: base(dateFrom, dateTo, priceFrom, priceTo, flightTypes)
		{
		}
	}
}
