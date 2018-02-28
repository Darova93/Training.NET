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

        public string Name { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public User()
        {

        }
    }
}