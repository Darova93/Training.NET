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
        public int Create(Answer anwser)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (anwser == null) return 0;

                anwser.CreatedDate = DateTime.Now;

                context.Answers.Add(anwser);
                context.SaveChanges();

                return anwser.Id;
            }
        }

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
    }
}
