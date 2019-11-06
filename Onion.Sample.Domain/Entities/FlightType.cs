namespace Onion.Sample.Domain.Entities
{
	public class FlightType : Entity
	{
		public string Name { get; private set; }

		public FlightType(string name)
		{
			Name = name;
		}
	}
}
