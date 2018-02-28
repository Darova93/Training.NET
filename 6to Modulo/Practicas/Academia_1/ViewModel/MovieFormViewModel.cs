using Academia_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academia_1.ViewModel
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<Genre> Genre { get; set; }
    }
}