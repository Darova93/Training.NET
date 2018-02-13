using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }

        public string Description { get; set; }

        public int Credits { get; set; }

        public int TeacherId { get; set; }

        //public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Class> Classes { get; set; }

    }
}
