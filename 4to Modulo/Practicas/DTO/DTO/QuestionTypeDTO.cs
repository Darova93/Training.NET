using System;

namespace DTO.DTO
{
    public class QuestionTypeDTO
    {
        public int QuestionTypeId { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get { return DateTime.Now; } set { } }
    }
}
