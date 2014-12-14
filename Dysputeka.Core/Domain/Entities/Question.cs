using System.Collections.Generic;
using Dysputeka.Core.Infrastructure;

namespace Dysputeka.Core.Domain.Entities
{
    public class Question : Entity
    {
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }

        public virtual User User { get; set; }
        public virtual Category Categorie { get; set; }
        public virtual ISet<Answer> Answers { get; set; }

    }
}