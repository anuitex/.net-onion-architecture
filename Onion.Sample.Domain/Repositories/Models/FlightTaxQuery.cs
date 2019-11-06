using System.Collections.Generic;

namespace Onion.Sample.Domain.Repositories.Models
{
	public class FlightTaxQuery : BaseQuery
	{
		public IEnumerable<FlightTaxQueryItem> LocationIds { get; private set; }

		public FlightTaxQuery(IEnumerable<FlightTaxQueryItem> locations)
		{
			LocationIds = locations;
		}
	}

	public class FlightTaxQueryItem
	{
		public long LocationFromId { get; private set; }
		public long LocationToId { get; private set; }

		public FlightTaxQueryItem(long locationFromId,long locationToId)
		{
			LocationFromId = locationFromId;
			LocationToId = locationToId;
		}
	}
}
