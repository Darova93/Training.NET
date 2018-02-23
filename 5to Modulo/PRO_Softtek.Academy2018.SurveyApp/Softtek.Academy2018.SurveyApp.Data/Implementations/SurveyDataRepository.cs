using Softtek.Academy2018.SurveyApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.SurveyApp.Domain.Model;

namespace Softtek.Academy2018.SurveyApp.Data.Implementations
{
    public class SurveyDataRepository : ISurveyRepository
    {
        public int Add(Survey survey)
        {
            using (var context = new SuerveyDbContext())
            {
                survey.CreatedDate = DateTime.Now;
                survey.IsArchived = false;

                context.Surveys.Add(survey);
                context.SaveChanges();

                return survey.Id;
            }
        }

        public bool AddQuestionToSurvey(int surveyid, int questionid)
        {
            using (var context = new SuerveyDbContext())
            {
                var currentsurvey = context.Surveys.SingleOrDefault(x => x.Id == surveyid);
                var currentquestion = context.Questions.SingleOrDefault(x => x.Id == questionid);

                if (currentsurvey == null || currentquestion == null) return false;

                currentsurvey.Questions.Add(currentquestion);
                currentquestion.Surveys.Add(currentsurvey);
                context.SaveChanges();

                return true;
            }
        }

        public bool Delete(Survey survey)
        {
            using (var context = new SuerveyDbContext())
            {
                Survey currentsurvey = context.Surveys.SingleOrDefault(q => q.Id == survey.Id);

                if ((currentsurvey == null) || (currentsurvey.IsArchived = true)) return false;

                currentsurvey.IsArchived = false;
                currentsurvey.ModifiedDate = (DateTime.Now);
                context.SaveChanges();

                return true;
            }
        }

        public Survey Get(int id)
        {
            using (var context = new SuerveyDbContext())
            {
                return context.Surveys.SingleOrDefault(s => s.Id == id && s.IsArchived == false);
            }
        }

        public ICollection<Question> GetQuestionBySurvey(int surveyid)
        {
            using (var context = new SuerveyDbContext())
            {
                return context.Surveys.SingleOrDefault(x => x.Id == surveyid && x.IsArchived==false).Questions.ToList();
            }
        }

        public bool RemoveQuestionToSurvey(int surveyid, int questionid)
        {
            using (var context = new SuerveyDbContext())
            {
                var currentsurvey = context.Surveys.SingleOrDefault(x => x.Id == surveyid);
                Question currentquestion = null;
                var findquestion = context.Questions.SingleOrDefault(x => x.Id == questionid);

                if(findquestion.Surveys.Any(x => x.Id == surveyid))
                {
                    currentquestion = findquestion;
                }

                if (currentsurvey == null || currentquestion == null) return false;

                currentsurvey.Questions.Remove(currentquestion);
                currentquestion.Surveys.Remove(currentsurvey);
                context.SaveChanges();

                return true;
            }
        }

        public bool Update(Survey survey)
        {
            using (var context = new SuerveyDbContext())
            {
                Survey oldsurvey = context.Surveys.SingleOrDefault(s => s.Id == survey.Id);

                if (oldsurvey == null) return false;

                oldsurvey.Title = survey.Title;
                oldsurvey.Description = survey.Description;
                oldsurvey.ModifiedDate = DateTime.Now;
                context.SaveChanges();

                return true;
            }
        }
    }
}
