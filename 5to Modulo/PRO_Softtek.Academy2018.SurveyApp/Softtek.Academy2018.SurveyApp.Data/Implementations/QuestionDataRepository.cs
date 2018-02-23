using Softtek.Academy2018.SurveyApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.SurveyApp.Domain.Model;

namespace Softtek.Academy2018.SurveyApp.Data.Implementations
{
    public class QuestionDataRepository : IQuestionRepository
    {
        public int Add(Question question)
        {
            using(var context = new SuerveyDbContext())
            {
                question.CreatedDate = DateTime.Now;
                if(question.QuestionTypeId == 1)
                {
                    question.IsActive = true;
                }
                else
                {
                    question.IsActive = false;
                }
                

                context.Questions.Add(question);
                context.SaveChanges();

                return question.Id;
            }
        }

        public bool AddOptionToQuestion(int optionid, int questionid)
        {
            using (var context = new SuerveyDbContext())
            {
                var currentoption = context.Options.SingleOrDefault(x => x.Id == optionid);
                var currentquestion = context.Questions.SingleOrDefault(x => x.Id == questionid);

                if (currentoption == null || currentquestion == null) return false;

                currentoption.Questions.Add(currentquestion);
                currentquestion.Options.Add(currentoption);
                context.SaveChanges();

                return true;
            }
        }

        public bool Delete(Question question)
        {
            using (var context = new SuerveyDbContext())
            {
                Question currentquestion = context.Questions.SingleOrDefault(q => q.Id == question.Id);

                if ((currentquestion == null) || (currentquestion.IsActive = false)) return false;

                currentquestion.IsActive = false;
                currentquestion.ModifiedDate = DateTime.Now;
                context.SaveChanges();

                return true;
            }
        }

        public Question Get(int id)
        {
            using (var context = new SuerveyDbContext())
            {
                var question = (context.Questions.SingleOrDefault(s => s.Id == id && s.IsActive == true));
                return question;
            }
        }

        public ICollection<Option> GetOptionByQuestion(int questionid)
        {
            using (var context = new SuerveyDbContext())
            {
                return context.Questions.SingleOrDefault(x=>x.Id==questionid).Options.ToList();
            }
        }

        public bool questionInSurvey(int id)
        {
            using (var context = new SuerveyDbContext())
            {
                return (context.Questions.SingleOrDefault(q => q.Id == id).Surveys.Count > 0);
            }
        }

        public bool RemoveOptionToQuestion(int optionid, int questionid)
        {
            using (var context = new SuerveyDbContext())
            {
                var currentquestion = context.Questions.SingleOrDefault(x => x.Id == questionid);
                Option currentoption = null;
                var findoption = context.Options.SingleOrDefault(x => x.Id == optionid);

                if (findoption.Questions.Any(x => x.Id == questionid))
                {
                    currentoption = findoption;
                }

                if (currentoption == null || currentquestion == null) return false;

                currentoption.Questions.Add(currentquestion);
                currentquestion.Options.Add(currentoption);
                context.SaveChanges();

                return true;
            }
        }

        public bool Update(Question question)
        {
            using (var context = new SuerveyDbContext())
            {
                Question oldquestion = context.Questions.SingleOrDefault(q => q.Id == question.Id);

                if (oldquestion == null) return false;

                oldquestion.Text = question.Text;
                oldquestion.QuestionTypeId = question.QuestionTypeId;

                switch (question.QuestionTypeId)
                {
                    case 1: oldquestion.IsActive = true;
                        break;
                    case 2: if (oldquestion.Options.Count() == 2) oldquestion.IsActive = true;
                        break;
                    case 3: if (oldquestion.Options.Count() == 3) oldquestion.IsActive = true;
                        break;
                    default:
                        oldquestion.IsActive = false;
                        break;
                }
                
                oldquestion.ModifiedDate = DateTime.Now;
                context.SaveChanges();

                return true;
            }
        }
    }
}
