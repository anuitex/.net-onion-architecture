using Onion.Sample.Domain.Entities;
using System.Collections.Generic;

namespace Onion.Sample.Domain.Repositories.Models
{
	public class HotelModel
	{
		public Hotel Hotel { get; private set; }
		public IEnumerable<HotelPrice> HotelPrices { get; private set; }
		public IEnumerable<HotelTax> Taxes { get; private set; }

		public HotelModel(Hotel hotel, IEnumerable<HotelPrice> hotelPrices, IEnumerable<HotelTax> taxes)
		{
			Hotel = hotel;
			HotelPrices = hotelPrices;
			Taxes = taxes;
		}
	}
}
