using Softtek.MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Softtek.MVC.ViewModels
{
    public class CreateUserViewModel
    {
        public int Id { get; set; }

        public string IS { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public DateTime CreatedDate { get; set; }

        public Double Salary { get; set; }

        [DisplayName("Birth Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateOfBirth { get; set; }

        public bool IsActive { get; set; }
    }
}