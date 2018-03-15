using Softtek.Academy.Final.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy.Final.Domain.Model;

namespace Softtek.Academy.Final.Data.Implementation
{
    public class QuestionDataRepository : IQuestionRepository
    {
        public Question Get(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                return context.Questions.SingleOrDefault(s => s.Id == id);
            }
        }

        public ICollection<Question> GetAll()
        {
            using (var context = new SurveySystemDbContext())
            {
                return context.Questions.ToList();
            }
        }

        public ICollection<Option> GetQuestionOptions(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (id <= 0) return null;

                Question question = Get(id);
                if (question == null) return null;

                return question.Options.ToList();
            }
        }

        public bool QuestionExists(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (id <= 0) return false;

                Question question = context.Questions.SingleOrDefault(q => q.Id == id);
                if (question == null) return false;

                return true;
            }
        }

        public bool SurveyHasQuestion(int questionid, int surveyid)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (questionid <= 0 || surveyid <= 0) return false;

                Question question = context.Questions.SingleOrDefault(q => q.Id == questionid);
                if (question == null) return false;

                return question.Surveys.Any(i => i.Id == surveyid);
            }
        }
    }
}
