using System;
using System.Collections.Generic;

namespace DataAccessEF.Entities
{
    public class Option
    {
        public int OptionId { get; set; }

        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
