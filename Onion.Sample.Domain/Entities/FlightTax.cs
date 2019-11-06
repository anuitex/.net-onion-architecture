namespace Onion.Sample.Domain.Entities
{
	public class FlightTax : Entity
	{
		public long HotelId { get; private set; }
		public decimal Amount { get; private set; }
	}
}
