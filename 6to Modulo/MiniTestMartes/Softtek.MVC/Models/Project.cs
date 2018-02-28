using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Softtek.MVC.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Collaborators { get; set; }

        public Project()
        {
            Collaborators = new HashSet<User>();
        }
    }
}