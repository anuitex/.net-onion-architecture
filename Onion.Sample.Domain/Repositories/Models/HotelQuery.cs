using Onion.Sample.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Onion.Sample.Domain.Repositories.Models
{
	public class HotelQuery : BaseQuery
	{
		public DateTime DateFrom { get; private set; }
		public DateTime DateTo { get; private set; }
		public decimal PriceFrom { get; private set; }
		public decimal PriceTo { get; private set; }
		public IEnumerable<RoomType> RoomTypes { get; private set; }

		public HotelQuery(DateTime dateFrom, DateTime dateTo, decimal priceFrom, decimal priceTo, IEnumerable<RoomType> roomTypes)
		{
			DateFrom = dateFrom;
			DateTo = dateTo;
			PriceFrom = priceFrom;
			PriceTo = priceTo;
			RoomTypes = roomTypes;
		}
	}
}
