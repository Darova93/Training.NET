namespace Softtek.Academy.Final.Domain.Model
{
    public class Answer : Entity
    {
        public int SurveyId { get; set; }

        public int? OptionId { get; set; }

        public int QuestionId { get; set; }

        public string OpenText { get; set; }

        public string Guest { get; set; }

        public virtual Survey Survey { get; set; }

        public virtual Option Option { get; set; }

        public virtual Question Question { get; set; }
    }
}
