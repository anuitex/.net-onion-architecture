using Onion.Sample.Domain.Entities;
using Onion.Sample.Domain.Repositories.Models;
using System;
using System.Collections.Generic;

namespace Onion.Sample.Application.ViewModels.Hotel
{
	public class HotelQueryView : HotelQuery
	{
		public HotelQueryView(DateTime dateFrom, DateTime dateTo, decimal priceFrom, decimal priceTo, IEnumerable<RoomType> roomTypes)
			: base(dateFrom, dateTo, priceFrom, priceTo, roomTypes)
		{
		}
	}
}
