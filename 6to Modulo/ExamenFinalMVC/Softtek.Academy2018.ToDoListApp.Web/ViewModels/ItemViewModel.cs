using Softtek.Academy2018.ToDoListApp.Web.Models;
using Softtek.Academy2018.ToDoListApp.Web.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Softtek.Academy2018.ToDoListApp.Web.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(6)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int PriorityId { get; set; }

        [DisplayName("Due Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DueDateValidation]
        public DateTime? DueDate { get; set; }

        [DisplayName("Tag")]
        public int TagId { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public string Action { get; set; }

        public ItemViewModel()
        {
            Id = 0;
            Action = "Save";

        }

        //public ItemViewModel(Item item)
        //{
        //    Id = item.Id;
        //    Title = item.Title;
        //    Description = item.Description;
        //    StatusId = item.StatusId;
        //    PriorityId = item.PriorityId;
        //    DueDate = item.DueDate;
        //    Action = "Update";
        //}
    }
}