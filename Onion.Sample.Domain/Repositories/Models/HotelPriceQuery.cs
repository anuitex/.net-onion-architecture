using System.Collections.Generic;

namespace Onion.Sample.Domain.Repositories.Models
{
	public class HotelPriceQuery : BaseQuery
	{
		public IEnumerable<long> HotelIds { get; private set; }

		public HotelPriceQuery(IEnumerable<long> hotelIds)
		{
			HotelIds = hotelIds;
		}
	}
}
