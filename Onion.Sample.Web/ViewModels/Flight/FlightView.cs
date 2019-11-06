using Onion.Sample.Domain.Repositories.Models;

namespace Onion.Sample.Application.ViewModels.Hotel
{
	public class FlightView : FlightPackageModel
	{
		public FlightView(FlightPackageModel hotelModel)
			: base(hotelModel.FlightPackage, hotelModel.FlightPrices, hotelModel.Taxes)
		{
		}
	}
}
