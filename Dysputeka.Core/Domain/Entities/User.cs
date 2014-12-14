using System.Collections.Generic;
using Dysputeka.Core.Infrastructure;
using NHibernate.Mapping;

namespace Dysputeka.Core.Domain.Entities
{
    public class User : Entity
    {
        public User()
        {
           // Tags = new List<Question>();
        }

        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual ISet<Question> Questions { get; set; }
        public virtual ISet<Answer> Answers { get; set; }
        public virtual ISet<Vote> Votes { get; set; }
    }
}