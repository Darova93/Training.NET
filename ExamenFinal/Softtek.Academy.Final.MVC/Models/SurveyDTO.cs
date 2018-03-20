using Softtek.Academy.Final.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Softtek.Academy.Final.MVC.Models
{
    public class SurveyDTO
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public Status Status { get; set; }

        ICollection<QuestionDTO> Questions { get; set; }

        public SurveyDTO()
        {
            Questions = new HashSet<QuestionDTO>();
        }
    }
}