using System;

namespace Onion.Sample.Domain.Entities
{
	public class HotelPrice : Entity
	{
		public long HotelId { get; private set; }
		public decimal Price { get; private set; }
		public DateTime DateFrom { get; private set; }
		public DateTime DateTo { get; private set; }
		public long RoomId { get; set; }

		public HotelPrice(long hotelId, decimal price, DateTime dateFrom, DateTime dateTo, long roomId)
		{
			HotelId = hotelId;
			Price = price;
			DateFrom = dateFrom;
			DateTo = dateTo;
			RoomId = roomId;
		}
	}
}
