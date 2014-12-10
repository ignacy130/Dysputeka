using System;
using Dysputeka.Core.Infrastructure.Commands;
using Dysputeka.Core.Domain.Entities;

namespace Dysputeka.Core.Domain.Commands
{
    public class DeleteCategory
    {
        public DeleteCategory(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

    public class DeleteCategoryCommand : CommandPerformer<DeleteCategory>
    {
        public override void Execute(DeleteCategory command)
        {
            Category category = Data.Get<Category>(command.Id); //pobieramy kategoria o takim ID

            if (category == null)  // sprawdzamy czy taka kategoria istnieje 
                return;

            /*pasowało by usunąć wszystkie pytania w danej kategorii.
             * cześc takich przypadków gdzie trzeba coś zrobić więcej podczas usuwania obsługujemy tu 
            np
            foreach (Question question in category.Questions)
            {
                Data.Delete(question);
            }
            
             a prostrze z nich obsługujemy przez mapowania w modelu  kliknij z ctrl w ->*/ CategoryMapping a;/* 
             
             */




            Data.Delete(category);   // Każemy nHibernate usunąć ten obiekt z bazy 
        }
    }
}
