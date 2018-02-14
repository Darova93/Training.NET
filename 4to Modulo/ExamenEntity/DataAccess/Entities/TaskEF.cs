using DTO.DTO;
using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class TaskEF
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsArchived { get; set; }
        public Status Status { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<TagEF> Tags { get; set; }
    }
}
