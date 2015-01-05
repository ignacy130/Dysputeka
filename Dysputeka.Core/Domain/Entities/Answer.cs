using Dysputeka.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysputeka.Core.Domain.Entities
{
    public class Answer : Entity
    {
        public virtual string Content { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime EditDate { get; set; }
        public virtual Rate Rate { get; set; }
        public virtual Vote Vote { get; set; }
        public virtual User User { get; set; }
        public virtual Question Question { get; set; }
    }
}
