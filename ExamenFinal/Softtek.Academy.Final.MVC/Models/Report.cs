using Softtek.Academy.Final.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Softtek.Academy.Final.MVC.Models
{
    public class Report
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<SurveyReport> Results { get; set; }
    }
}