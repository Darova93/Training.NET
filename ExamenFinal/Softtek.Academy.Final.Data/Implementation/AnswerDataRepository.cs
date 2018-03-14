using Softtek.Academy.Final.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy.Final.Domain.Model;

namespace Softtek.Academy.Final.Data.Implementation
{
    public class AnswerDataRepository : IAnswerRepository
    {
        public Answer Get(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                return context.Answers.SingleOrDefault(s => s.Id == id);
            }
        }

        public ICollection<Answer> GetAll()
        {
            using (var context = new SurveySystemDbContext())
            {
                return context.Answers.ToList();
            }
        }

        public ICollection<Answer> GetSurveyAnswers(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (id <= 0) return null;

                Survey survey = context.Surveys.SingleOrDefault(s => s.Id == id);
                if (survey == null) return null;

                return context.Answers.Where(s => s.SurveyId == id).ToList();
            }
        }
    }
}
