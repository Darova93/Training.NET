using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Softtek.Academy.Final.WebAPI.Models
{
    public class AnswerDTO
    {
        public int Id { get; set; }

        public int SurveyId { get; set; }

        public int QuestionId { get; set; }

        public string OpenText { get; set; }

        public int? OptionId { get; set; }

        public string Guest { get; set; }
    }
}