using Softtek.Academy.Final.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy.Final.Domain.Model;

namespace Softtek.Academy.Final.Data.Implementation
{
    public class OptionDataRepository : IOptionRepository
    {
        public ICollection<Option> GetQuestionOptions(int id)
        {
            using (var context = new SurveySystemDbContext())
            {
                if (id <= 0) return null;

                Question question = context.Questions.SingleOrDefault(s => s.Id == id);
                if (question == null) return null;

                return context.Options.Where(i => i.QuestionId == id).ToList();
            }
        }
    }
}
