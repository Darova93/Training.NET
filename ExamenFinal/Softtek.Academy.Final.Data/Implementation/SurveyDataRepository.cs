using Softtek.Academy.Final.Data.Contracts;
using Softtek.Academy.Final.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Softtek.Academy.Final.Data.Implementation
{
    public class SurveyDataRepository : ISurveyRepository
    {
        public bool Archive(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (id <= 0) return false;

                Survey survey = Get(id);

                if (survey == null) return false;

                survey.IsActive = false;

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

                context.SaveChanges();

                return true;
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

                context.Surveys.Add(survey);
                context.SaveChanges();

                return survey.Id;
            }
        }

        public Survey Get(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                return context.Surveys.SingleOrDefault(s => s.Id == id);
            }
        }

        public ICollection<Survey> GetAll()
        {
            using (var context = new SurveySystemDbContext())
            {
                return context.Surveys.ToList();
            }
        }

        public bool Restore(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (id <= 0) return false;

                Survey survey = Get(id);

                if (survey==null) return false;

                survey.IsActive = true;

                context.SaveChanges();

                return true;
            }
        }

        public bool SurveyExists(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (id <= 0) return false;

                Survey survey = context.Surveys.SingleOrDefault(s => s.Id == id);
                if (survey == null) return false;

                return true;
            }
        }

        public bool Update(Survey survey)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (survey == null) return false;
                if (survey.Id <= 0) return false;

                Survey oldsurvey = Get(survey.Id);

                oldsurvey.Title = survey.Title;
                oldsurvey.Description = survey.Description;

                context.SaveChanges();

                return true;
            }
        }
    }
}
