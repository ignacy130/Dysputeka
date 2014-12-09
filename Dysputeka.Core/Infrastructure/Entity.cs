using System;

namespace PortalKol.Core.Infrastructure
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; set; }
    }
}