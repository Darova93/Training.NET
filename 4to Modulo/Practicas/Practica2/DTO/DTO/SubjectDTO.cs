using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO
{
    public class SubjectDTO
    {
        public int SubjectId { get; set; }

        public string Description { get; set; }

        public int Credits { get; set; }

        public int TeacherId { get; set; }
    }
}
