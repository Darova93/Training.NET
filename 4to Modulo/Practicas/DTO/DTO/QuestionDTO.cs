using System;
using System.Collections.Generic;

namespace DTO.DTO
{
    public class QuestionDTO
    {
        public int QuestionId { get; set; }

        public string Text { get; set; }

        public int QuestionTypeId { get; set; }

        public bool IsActive { get; set; }

        public bool IsRequired { get; set; }

        public DateTime CreateDate { get { return DateTime.Now; } set { } }

        public DateTime? ModifiedDate { get; set; }

        public QuestionTypeDTO QuestionType { get; set; }

        public IEnumerable<OptionDTO> Option { get; set; }
    }
}
