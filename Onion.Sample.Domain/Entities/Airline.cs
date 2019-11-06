namespace Onion.Sample.Domain.Entities
{
	public class Airline : Entity
	{
		public string Name { get; private set; }

		public Airline(string name)
		{
			Name = name;
		}
	}
}
