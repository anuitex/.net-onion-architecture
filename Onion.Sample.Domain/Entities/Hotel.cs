namespace Onion.Sample.Domain.Entities
{
	public class Hotel : Entity
	{
		public string Name { get; private set; }
		public string Description { get; private set; }
		public int Rating { get; private set; }
		public Location Location { get; private set; }
		public long LocationId { get; private set; }

		public Hotel(string name, string description, int rating, long locationId)
		{
			LocationId = locationId;
		}
	}
}
