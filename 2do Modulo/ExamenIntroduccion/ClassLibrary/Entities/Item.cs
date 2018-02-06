using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime DueDate { get; set; }
        public TimeSpan Range { get; set; }
        public int Priority { get; set; }
        public Status StatusId { get; set; }
        public bool IsArchived { get; set; }

        public Item(int id, string title, string description, DateTime createdate)
        {
            Id = id;
            Title = title;
            Description = description;
            CreateDate = createdate;
            ModifyDate = DateTime.Now;
            DueDate = DateTime.Now;
            Range = DueDate.Subtract(CreateDate);
            Priority = 1;
            StatusId = Status.Draft;
            IsArchived = false;
        }

    }

    
}
