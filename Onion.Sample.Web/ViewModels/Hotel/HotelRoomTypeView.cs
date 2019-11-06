using Onion.Sample.Domain.Entities;

namespace Onion.Sample.Application.ViewModels.Hotel
{
	public class HotelRoomTypeView
	{
		public long Id { get; private set; }
		public string Name { get; private set; }

		public HotelRoomTypeView(RoomType roomType)
		{
			Name = roomType.Name;
			Id = roomType.Id;
		}
	}
}
