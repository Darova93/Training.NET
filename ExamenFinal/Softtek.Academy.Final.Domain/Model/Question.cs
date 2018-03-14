using System.Collections.Generic;

namespace Softtek.Academy.Final.Domain.Model
{
    public class Question : Entity
    {
        public string Text { get; set; }

        public int QuestionTypeId { get; set; }

        public QuestionType QuestionType { get; set; }

        public virtual ICollection<Option> Options { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }

        public Question()
        {
            Options = new HashSet<Option>();
            Surveys = new HashSet<Survey>();
        }
    }
}
