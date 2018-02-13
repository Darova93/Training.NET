using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Class
    {
        public int ClassId { get; set; }

        public int TeacherId { get; set; }

        public int SubjectId { get; set; }

        public string Schedule { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual ICollection<Asignation> Asignations { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
