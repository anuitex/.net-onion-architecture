namespace Onion.Sample.Domain.Entities
{
	public class HotelTax : Entity
	{
		public Location Location  { get; private set; }
		public long LocationId { get; private set; }
		public decimal Amount { get; private set; }
	}
}
