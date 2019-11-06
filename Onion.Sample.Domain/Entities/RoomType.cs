namespace Onion.Sample.Domain.Entities
{
	public class RoomType : Entity
	{
		public string Name { get; private set; }

		public RoomType(string name)
		{
			Name = name;
		}
	}
}
