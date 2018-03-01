using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Softtek.MVC.Models
{
    public class User
    {
        public int Id { get; set; }

        public string IS { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Double Salary { get; set; }

        public bool IsActive { get; set; }

        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public User()
        {
        }
    }
}