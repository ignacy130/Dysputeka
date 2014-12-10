using System;
using Dysputeka.Core.Infrastructure.Commands;
using Dysputeka.Core.Infrastructure.Commands;
using Dysputeka.Core.Domain.Entities;

namespace Dysputeka.Core.Domain.Commands
{
    public class EditCategory : CommandData
    {
        public EditCategory(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

    }

    public class EditCategoryCommand : CommandPerformer<EditCategory>
    {
        public override void Execute(EditCategory command)
        {
            var category = Data.Get<Category>(command.Id);  // w ten sposób pobieramy kategorie o podanym ID 
            category.Name = command.Name;  // w ten sposób ją edytujemy nHibernate sam to zaktualizuje w bazie
            

        }
    }
}
