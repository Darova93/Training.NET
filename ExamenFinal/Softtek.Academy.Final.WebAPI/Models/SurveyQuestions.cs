using Softtek.Academy.Final.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Softtek.Academy.Final.WebAPI.Models
{
    public class SurveyQuestions
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public Status Status { get; set; }

        public ICollection<QuestionDTO> Questions { get; set; }
    }
}