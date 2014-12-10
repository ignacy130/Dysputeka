using System.Collections.Generic;
using Dysputeka.Core.Infrastructure;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Dysputeka.Core.Domain.Entities
{
    public class Category : Entity
    {
        public virtual string Name { get; set; }
        public virtual ISet<Question> Questions { get; set; }



    }

    public class CategoryMapping : ClassMapping<Category> // kod mapera 
    {
        public CategoryMapping()
        {
            Set(x => x.Questions,
                mapper =>
                {
                    mapper.Inverse(true);
                    mapper.Cascade(Cascade.All | Cascade.DeleteOrphans);
                }); // przez dodanie takiego kodu automatycznie przy usunięciu kategorii usuną się powiązane z nią pytania
            
        }
    }
}