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
        public bool AddQuestionToSurvey(int questionid, int surveyid)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (questionid <= 0 || surveyid <= 0) return false;

                Question question = Get(questionid);
                if (question == null) return false;

                Survey survey = context.Surveys.SingleOrDefault(s => s.Id == surveyid);
                if (survey == null) return false;

                question.Surveys.Add(survey);
                survey.Questions.Add(question);

                context.SaveChanges();

                return true;
            }
        }

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

        public ICollection<Question> GetSurveyQuestions(int surveyid)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (surveyid <= 0) return null;

                Survey survey = context.Surveys.Where(s => s.Id == surveyid).SingleOrDefault();
                if (survey == null) return null;
                                
                return survey.Questions.ToList(); ;
            }
        }

        public bool RemoveQuestionFromSurvey(int questionid, int surveyid)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (questionid <= 0 || surveyid <= 0) return false;

                Question question = Get(questionid);
                if (question == null) return false;

                Survey survey = context.Surveys.SingleOrDefault(s => s.Id == surveyid);
                if (survey == null) return false;

                question.Surveys.Remove(survey);
                survey.Questions.Remove(question);

                context.SaveChanges();

                return true;
            }
        }
    }
}
