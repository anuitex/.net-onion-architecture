namespace Onion.Sample.Domain.Entities
{
    public class Role : Entity
    {
        public string Name { get; private set; }

        public Role(string name)
        {
            Name = name;
        }
    }
}
