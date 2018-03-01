using Softtek.MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Softtek.MVC.ViewModels
{
    public class CreateUserViewModel
    {
        public int Id { get; set; }

        public string IS { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedDate { get; set; }

        public Double Salary { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool IsActive { get; set; }
    }
}