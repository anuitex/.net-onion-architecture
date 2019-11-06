using Onion.Sample.Domain.Repositories.Models;

namespace Onion.Sample.Application.ViewModels.Hotel
{
	public class HotelView : HotelModel
	{
		public HotelView(HotelModel hotelModel)
			: base(hotelModel.Hotel, hotelModel.HotelPrices, hotelModel.Taxes)
		{
		}
	}
}
