namespace Onion.Sample.Domain.Entities
{
	public class Room : Entity
	{
		public RoomType RoomType { get; private set; }
		public long HotelId { get; private set; }

		public Room(RoomType roomType, long hotelId)
		{
			RoomType = roomType;
			HotelId = hotelId;
		}
	}
}
