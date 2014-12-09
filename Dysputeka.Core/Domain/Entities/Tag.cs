using PortalKol.Core.Infrastructure;

namespace PortalKol.Core.Domain.Entities
{
    public class Tag : Entity
    {
        public virtual Organization Organization { get; set; }
        public virtual string Name { get; set; }
    }
}