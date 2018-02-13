using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Asignation
    {
        public int AsignationId { get; set; }

        public int StudentId { get; set; }

        public int ClassId { get; set; }

        public int Grade { get; set; }

        public virtual Student Student { get; set; }

        public virtual Class Class { get; set; }
    }
}
