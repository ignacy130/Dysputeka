using Dysputeka.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysputeka.Core.Domain.Entities
{
    public class Vote : Entity
    {
        public virtual Vote Opinion { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual User User { get; set; }
    }
}
