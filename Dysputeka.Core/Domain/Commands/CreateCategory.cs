using System;
using Dysputeka.Core.Domain.Entities;
using Dysputeka.Core.Infrastructure;
using Dysputeka.Core.Infrastructure.Commands;

namespace Dysputeka.Core.Domain.Commands
{
    public class CreateCategory : CommandData // nazwa taka jak pliku
    {
        


        // TU dodajemu pola jakie ktoś ma nam podać 
        public string Name { get; set; }
        
        //przykład dodania linku do powiązanego Modelu
        //public Guid questionId;


        //Konstruktor szybko tworzymy przez alt insert (resharper)
        public CreateCategory(string name)
        {
            Name = name;
        }
    }

    public class CreateCategoryCommand : CommandPerformer<CreateCategory> // nazwa taka jak pliku + Command ; <nazwa taka jak pliku>
    {
        public override void Execute(CreateCategory command)
        {

            var category = new Category()
            {
                Name = command.Name
            };



                /*
                 * Title = command.Title,                                           // w ten sposób wypełniamy pola typu trostego int string...
                 * Organization = Data.Load<Organization>(command.OrganizationId),  // w ten sposób wypełniamy powiązania między modelami 
                 * DateTime =  DateTimeGetter.GetCurrentDateTime(),                 // w ten sposób wypełniamy date
                 */

            Data.Save(category);
        }
    }
}
