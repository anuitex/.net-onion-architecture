namespace Onion.Sample.Domain.Entities
{
	public class FlightPrice : Entity
	{
		public long FlightId { get; private set; }
		public decimal Price { get; private set; }

		public FlightPrice(long flightId, decimal price)
		{
			FlightId = flightId;
			Price = price;
		}
	}
}
