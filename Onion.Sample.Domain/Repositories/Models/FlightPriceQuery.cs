using System.Collections.Generic;

namespace Onion.Sample.Domain.Repositories.Models
{
	public class FlightPriceQuery : BaseQuery
	{
		public IEnumerable<long> FlightIds { get; private set; }

		public FlightPriceQuery(IEnumerable<long> flightIds)
		{
			FlightIds = flightIds;
		}
	}
}
