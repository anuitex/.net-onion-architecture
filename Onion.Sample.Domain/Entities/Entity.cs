using System;
namespace Onion.Sample.Domain.Entities
{
    public class Entity
    {
        public long Id { get; private set; }
        public DateTime CreationDate { get; private set; }

        public Entity()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}
