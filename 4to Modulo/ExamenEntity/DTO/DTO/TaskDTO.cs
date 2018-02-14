using System;

namespace DTO.DTO
{
    public class TaskDTO
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get { return 1; }  set { } }
        public DateTime DueDate { get { return DateTime.Now.AddDays(7); } set { } }
        public Status Status { get { return Status.Draft; } set { } }
        public bool IsArchived { get { return false; } set { } }
        public DateTime CreateDate { get { return DateTime.Now; } set { } }
    }
}
