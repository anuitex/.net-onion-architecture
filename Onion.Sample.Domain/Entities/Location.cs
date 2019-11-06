namespace Onion.Sample.Domain.Entities
{
	public class Location : Entity
	{
		public string Country { get; private set; }
		public string City { get; private set; }
		public string Address { get; private set; }
		public long Latitude { get; private set; }
		public long Longitude { get; private set; }
	}
}
