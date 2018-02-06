using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsGlobal { get; set; }
        public int UserId { get; set; }
        public int Tasks { get; set; }

        public Tag (int id, string name, bool isglobal, int userid)
        {
            Id = id;
            Name = name;
            IsGlobal = isglobal;
            UserId = userid;
            Tasks = 0;
        }

    }
}
