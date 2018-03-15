namespace Softtek.Academy.Final.Domain.Model
{
    public class Option : Entity
    {
        public string Text { get; set; }

        public int? Value { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
