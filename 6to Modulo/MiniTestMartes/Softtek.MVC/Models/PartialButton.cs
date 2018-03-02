using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace Softtek.MVC.Models
{
    public class PartialButton
    {
        public string ButtonType { get; set; }

        public string Action { get; set; }

        public string GlyphIcon { get; set; }

        public string Text { get; set; }

        public int Id { get; set; }

        public string ActionParameter
        {
            get
            {
                var param = new StringBuilder(@"/");
                param.Append($"{Id}");

                return param.ToString();
            }

        }
    }
}