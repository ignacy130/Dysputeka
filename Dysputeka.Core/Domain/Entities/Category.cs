using System.Collections.Generic;
using Dysputeka.Core.Infrastructure;

namespace Dysputeka.Core.Domain.Entities
{
    public class Category : Entity
    {
        public virtual string Name { get; set; }
        public virtual ISet<Question> Questions { get; set; }

    }
}