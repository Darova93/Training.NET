using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class TagEF
    {
        public int TagId { get; set; }
        public string Description { get; set; }
        public bool IsArchived { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<TaskEF> Tasks { get; set; }
    }
}
