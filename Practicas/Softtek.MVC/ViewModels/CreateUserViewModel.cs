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
        public int? Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public int ProjectId { get; set; }

        public IEnumerable<Project> Projects { get; set; }

        public CreateUserViewModel()
        {
            Id = 0;
        }

        public CreateUserViewModel(User user)
        {
            Id = user.Id;
            Name = user.Name;
            ProjectId = user.ProjectId;
        }
    }
}