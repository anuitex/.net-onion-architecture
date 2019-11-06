using Onion.Sample.Domain.Entities;

namespace Onion.Sample.Application.ViewModels
{
	public class FlightTypeView
	{
		public long Id { get; private set; }
		public string Name { get; private set; }

		public FlightTypeView(FlightType flightType)
		{
			Name = flightType.Name;
			Id = flightType.Id;
		}
	}
}
