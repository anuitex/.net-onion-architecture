using System.Collections.Generic;

namespace Onion.Sample.Domain.Entities
{
	public class FlightPackage : Entity
	{
		public IEnumerable<Flight> Flights { get; set; }

		public FlightPackage(IEnumerable<Flight> flights)
		{
			Flights = flights;
		}
	}
}
