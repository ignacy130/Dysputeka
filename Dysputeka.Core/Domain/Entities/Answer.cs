using Dysputeka.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Dysputeka.Core.Domain.Entities
{
    public class Answer : Entity
    {
        public virtual string Content { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime EditDate { get; set; }
        public virtual Rate Rate { get; set; }
        public virtual ISet<Vote> Vote { get; set; } // jedna odpowiedz może mieć wiele głosów coś jak lajki w FB
        public virtual User User { get; set; }
        public virtual Question Question { get; set; }
    }

    public class AnswerMapping : ClassMapping<Answer> // kod mapera 
    {
        public AnswerMapping()
        {
            // todo mapowanie enuma
            Set(x => x.Vote,
                mapper =>
                {
                    mapper.Inverse(true);
                    mapper.Cascade(Cascade.All | Cascade.DeleteOrphans);
                });
                // przez dodanie takiego kodu automatycznie przy usunięciu kategorii usuną się powiązane z nią pytania
        }
    }


}