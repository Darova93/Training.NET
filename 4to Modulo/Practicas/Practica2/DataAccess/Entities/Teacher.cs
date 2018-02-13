using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        //public virtual ICollection<Subject> Subjects { get; set; }

        public virtual ICollection<Class> Classes { get; set; }

    }
}
