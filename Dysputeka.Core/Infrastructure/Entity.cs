using System;

namespace Dysputeka.Core.Infrastructure
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