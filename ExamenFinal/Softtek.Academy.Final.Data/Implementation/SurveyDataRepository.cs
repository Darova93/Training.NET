using Softtek.Academy.Final.Data.Contracts;
using Softtek.Academy.Final.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

                Survey oldsurvey = context.Surveys.SingleOrDefault(s => s.Id == survey.Id && s.IsArchived == false);
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

                Survey survey = context.Surveys.SingleOrDefault(s => s.Id == id && s.IsArchived == false);
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

                Survey survey = context.Surveys.SingleOrDefault(s => s.Id == id && s.IsArchived == false);
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

                Survey survey = context.Surveys.SingleOrDefault(s => s.Id == id && s.IsArchived == false);
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

                Survey survey = context.Surveys.SingleOrDefault(s => s.Id == id && s.IsArchived == false);

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

                Survey survey = context.Surveys.SingleOrDefault(s => s.Id == surveyid && s.IsArchived == false);
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

                Survey survey = context.Surveys.SingleOrDefault(s => s.Id == surveyid && s.IsArchived == false);
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

                Survey survey = context.Surveys.SingleOrDefault(s => s.Id == id && s.IsArchived == false);
                if (survey == null) return null;

                return survey.Answers.ToList();
            }
        }

        public ICollection<Question> GetSurveyQuestions(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (id <= 0) return null;

                Survey survey = context.Surveys.SingleOrDefault(s => s.Id == id && s.IsArchived == false);
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

        public bool UserSurveyExists(Answer answer)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (answer.SurveyId <= 0) return false;

                Survey survey = context.Surveys.SingleOrDefault(s => s.Id == answer.SurveyId && s.IsArchived == false && s.IsActive == true && s.Status == Status.Ready);

                if (survey == null) return false;

                if (!survey.Questions.Any(q => q.Id == answer.QuestionId)) return false;

                if (answer.OptionId != null)
                {
                    if (!survey.Questions.SingleOrDefault(q => q.Id == answer.QuestionId).Options.Any(o => o.Id == answer.OptionId)) return false;
                }

                return true;
            }
        }

        public bool HasOpenValue(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                var survey = context.Surveys.SingleOrDefault(s => s.Id == id && s.IsArchived == false);
                if (survey == null) return true;

                if (survey.Questions.Count() == 0) return true;

                if (survey.Questions.Any(q => q.QuestionTypeId == 1 || q.QuestionTypeId == 3)) return true;

                return false;
            }
        }

        public ICollection<SurveyReport> Report(int id)
        {
            List<SurveyReport> report = new List<SurveyReport>();

            string connstring = "Data Source=STKEND13944\\SQLEXPRESS; Initial Catalog = SurveySystemDb; User Id=sa; Password=softtek.001";
            SqlConnection connstringobj = new SqlConnection(connstring);

            SqlCommand command = new SqlCommand("dbo.usp_SurveyReport", connstringobj);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@surveyId", SqlDbType.Int).Value = id;

            connstringobj.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                report.Add(new SurveyReport
                {
                    Question = reader["Question"].ToString(),
                    Average = (int)reader["Average"]
                });
            }
            connstringobj.Close();

            return report;
        }

        public ICollection<Question> GetNotSurveyQuestions(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                ICollection<Question> result = new HashSet<Question>();

                if (id <= 0) return null;

                if (!SurveyExists(id)) return null;

                var questions = context.Questions.ToList();

                foreach (var question in questions)
                {
                    question.Surveys.ToList();
                    if (question.Surveys.Any(s => s.Id == id))
                    {

                    }
                    else
                    {
                        result.Add(question);
                    }
                }

                return result;
            }
        }

    }
}
