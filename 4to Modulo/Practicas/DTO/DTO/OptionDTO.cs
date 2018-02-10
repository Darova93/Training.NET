using System;

namespace DTO.DTO
{
    public class OptionDTO
    {
        public int OptionId { get; set; }

        public string Text { get; set; }

        public DateTime CreateDate { get { return DateTime.Now; } set { } }

        public DateTime ModifiedDate { get { return DateTime.Now; } set { } }
    }
}
