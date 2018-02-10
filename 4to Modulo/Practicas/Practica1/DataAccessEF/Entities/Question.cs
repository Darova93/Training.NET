using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessEF.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string Text { get; set; }

        [ForeignKey("QuestionType")]
        public int QuestionTypeId { get; set; }

        public bool IsActive { get; set; }

        public bool IsRequired { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual QuestionType QuestionType { get; set; }

        public virtual ICollection<Option> Option { get; set; }
    }
}
