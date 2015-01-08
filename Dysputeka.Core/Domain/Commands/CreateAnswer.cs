using Dysputeka.Core.Domain.Entities;
using Dysputeka.Core.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysputeka.Core.Domain.Commands
{
    public class CreateAnswer : CommandData
    {
        public string Content { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        public Rate Rate { get; set; }
        public Vote Vote { get; set; }
        public User User { get; set; }
        public Question Question { get; set; }

        public CreateAnswer(string Content)
        {
            this.Content = Content;
        }
    }

    public class CreateAnswerCommand : CommandPerformer<CreateAnswer>
    {
        public override void Execute(CreateAnswer command)
        {
            var answer = new Answer()
            {
                Content = command.Content,
                CreateDate = command.CreateDate,
                EditDate = command.EditDate,
                Rate = Data.Load<Rate>(command.Rate),
                Vote = Data.Load<Vote>(command.Vote),
                User = Data.Load<User>(command.User),
                Question = Data.Load<Question>(command.Question),
            };

            Data.Save(answer);
        }
    }
}
