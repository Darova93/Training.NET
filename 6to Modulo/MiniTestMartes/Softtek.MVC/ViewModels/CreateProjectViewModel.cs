using Softtek.MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Softtek.MVC.ViewModels
{
    public class CreateProjectViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Area { get; set; }

        public string TechnologyStack { get; set; }

        public IEnumerable<User> Collaborators { get; set; }

        //public CreateProjectViewModel()
        //{
        //    Id = 0;
        //}

        //public CreateProjectViewModel(Project project)
        //{
        //    Id = project.Id;
        //    Name = project.Name;
        //}
    }
}