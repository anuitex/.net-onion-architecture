using Onion.Sample.Domain.Common;
using Onion.Sample.Domain.Entities;
using Onion.Sample.Domain.Repositories;
using Onion.Sample.Domain.Repositories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Sample.Domain.Services
{
	public class HotelManager : IHotelManager
	{
		private IHotelFabric _hotelFabric;
		private IHotelTaxRepository _taxRepository;
		private IHotelPriceRepository _hotelPriceRepository;

		public HotelManager(IHotelFabric hotelFabric, IHotelTaxRepository taxRepository,
			IHotelPriceRepository hotelPriceRepository)
		{
			_hotelFabric = hotelFabric;
			_taxRepository = taxRepository;
			_hotelPriceRepository = hotelPriceRepository;
		}

		public async Task<IEnumerable<HotelModel>> QueryAsync(HotelApiType hotelApiType, HotelQuery hotelQueryModel)
		{
			using (var hotelRepository = await _hotelFabric.CreateInstanceAsync(hotelApiType))
			{
				IEnumerable<Hotel> hotels = await hotelRepository.QueryAsync(hotelQueryModel);
				var locations = hotels.Select(hotel => hotel.LocationId);
				IEnumerable<HotelTax> taxes = await _taxRepository.QueryAsync(new HotelTaxQuery(locations));
				IEnumerable<HotelPrice> hotelPrices = await _hotelPriceRepository.QueryAsync(new HotelPriceQuery(hotels.Select(hotel => hotel.Id)));
				var hotelModels = new List<HotelModel>();
				foreach(var hotel in hotels)
				{
					//TODO: Calculate tax
					hotelModels.Add(new HotelModel(hotel,
						hotelPrices.Where(hotelPrice=> hotelPrice.HotelId==hotel.Id),
						taxes.Where(tax => tax.LocationId == hotel.LocationId)
						));
				}
				return hotelModels;
			}
		}
	}
}
