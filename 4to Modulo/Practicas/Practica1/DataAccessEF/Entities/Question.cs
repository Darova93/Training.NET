namespace DataAccessEF.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string Text { get; set; }

        public int QuestionTypeId { get; set; }

        public bool IsActive { get; set; }

        public bool IsRequired { get; set; }
    }
}
