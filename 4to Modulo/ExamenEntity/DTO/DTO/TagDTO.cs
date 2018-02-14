using System;

namespace DTO.DTO
{
    public class TagDTO
    {
        public int TagId { get; set; }
        public string Description { get; set; }
        public bool IsArchived { get { return false; } set { } }
        public DateTime CreateDate { get; set; }
    }
}
