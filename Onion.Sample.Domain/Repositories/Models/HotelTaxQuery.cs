using System.Collections.Generic;

namespace Onion.Sample.Domain.Repositories.Models
{
	public class HotelTaxQuery : BaseQuery
	{
		public IEnumerable<long> LocationIds { get; private set; }

		public HotelTaxQuery(IEnumerable<long> locationIds)
		{
			LocationIds = locationIds;
		}
	}
}
