using Softtek.Academy.Final.Data.Contracts;
using Softtek.Academy.Final.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Softtek.Academy.Final.Data.Implementation
{
    public class SurveyDataRepository : ISurveyRepository
    {
        public Survey Get(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                return context.Surveys.SingleOrDefault(s => s.Id == id && s.IsArchived == false);
            }
        }

        public ICollection<Survey> GetAll()
        {
            using (var context = new SurveySystemDbContext())
            {
                return context.Surveys.Where(s => s.IsArchived == false).ToList();
            }
        }

        public int Create(Survey survey)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (survey == null) return 0;

                survey.CreatedDate = DateTime.Now;
                survey.Status = Status.Draft;
                survey.IsActive = false;
                survey.IsArchived = false;

                context.Surveys.Add(survey);
                context.SaveChanges();

                return survey.Id;
            }
        }

        public bool Update(Survey survey)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (survey == null) return false;
                if (survey.Id <= 0) return false;

                Survey oldsurvey = Get(survey.Id);
                if (oldsurvey == null) return false;

                oldsurvey.Title = survey.Title;
                oldsurvey.Description = survey.Description;
                oldsurvey.ModifiedDate = DateTime.Now;

                context.SaveChanges();

                return true;
            }
        }

        public bool Delete(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (id <= 0) return false;

                Survey survey = Get(id);
                if (survey == null) return false;

                survey.IsArchived = true;
                survey.ModifiedDate = DateTime.Now;

                context.SaveChanges();

                return true;
            }
        }

        public bool Activate(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (id <= 0) return false;

                Survey survey = Get(id);
                if (survey == null) return false;

                survey.IsActive = true;
                survey.ModifiedDate = DateTime.Now;

                context.SaveChanges();

                return true;
            }
        }

        public bool DeActivate(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (id <= 0) return false;

                Survey survey = Get(id);
                if (survey == null) return false;

                survey.IsActive = false;
                survey.ModifiedDate = DateTime.Now;

                context.SaveChanges();

                return true;
            }
        }

        public bool ChangeStatus(int id, Status status)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (id <= 0) return false;

                Survey survey = Get(id);

                if (survey == null) return false;

                survey.Status = status;
                survey.ModifiedDate = DateTime.Now;

                context.SaveChanges();

                return true;
            }
        }

        public bool AddQuestionToSurvey(int questionid, int surveyid)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (questionid <= 0 || surveyid <= 0) return false;

                Question question = context.Questions.FirstOrDefault(q => q.Id == questionid);
                if (question == null) return false;

                Survey survey = Get(surveyid);
                if (survey == null) return false;

                question.Surveys.Add(survey);
                survey.Questions.Add(question);
                survey.ModifiedDate = DateTime.Now;

                context.SaveChanges();

                return true;
            }
        }

        public bool RemoveQuestionFromSurvey(int questionid, int surveyid)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (questionid <= 0 || surveyid <= 0) return false;

                Question question = context.Questions.FirstOrDefault(q => q.Id == questionid);
                if (question == null) return false;

                Survey survey = Get(surveyid);
                if (survey == null) return false;

                question.Surveys.Remove(survey);
                survey.Questions.Remove(question);
                survey.ModifiedDate = DateTime.Now;

                context.SaveChanges();

                return true;
            }
        }

        public ICollection<Answer> GetSurveyAnswers(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (id <= 0) return null;

                Survey survey = Get(id);
                if (survey == null) return null;

                return survey.Answers.ToList();
            }
        }

        public ICollection<Question> GetSurveyQuestions(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (id <= 0) return null;

                Survey survey = Get(id);
                if (survey == null) return null;

                return survey.Questions.ToList();
            }
        }

        public bool SurveyExists(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (id <= 0) return false;

                Survey survey = Get(id);
                if (survey == null) return false;

                return true;
            }
        }
        
    }
}
