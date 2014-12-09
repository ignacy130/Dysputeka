using System.Collections.Generic;
using NHibernate.Mapping;
using PortalKol.Core.Infrastructure;

namespace PortalKol.Core.Domain.Entities
{
    public class Organization : Entity
    {
        public Organization()
        {
            Tags = new List<Tag>();
        }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<Tag> Tags { get; set; }
    }
}