using System.Collections.Generic;
using Dysputeka.Core.Infrastructure;
using NHibernate.Mapping;

namespace Dysputeka.Core.Domain.Entities
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