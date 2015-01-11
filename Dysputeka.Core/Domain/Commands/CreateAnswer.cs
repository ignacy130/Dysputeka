using Dysputeka.Core.Domain.Entities;
using Dysputeka.Core.Infrastructure;
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
        public CreateAnswer(string content, Rate rate, Guid userId, Guid questionId)
        {
            Content = content;
            Rate = rate;
            UserId = userId;
            QuestionId = questionId;
        }

        public string Content { get; set; }
        public Rate Rate { get; set; }
        public Guid UserId { get; set; }
        public Guid QuestionId { get; set; }

    }

    public class CreateAnswerCommand : CommandPerformer<CreateAnswer>
    {
        public override void Execute(CreateAnswer command)
        {
            var answer = new Answer()
            {
                Content = command.Content,
                CreateDate = DateTimeGetter.GetCurrentDateTime(),
                Rate = command.Rate,  //to jest enum nie trzeba go w ten sposób ładować 
                User = Data.Load<User>(command.UserId),
                Question = Data.Load<Question>(command.QuestionId),
            };

            Data.Save(answer);
        }
    }
}
