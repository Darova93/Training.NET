using Softtek.Academy2018.SurveyApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.SurveyApp.Domain.Model;

namespace Softtek.Academy2018.SurveyApp.Data.Implementations
{
    public class QuestionTypeDataRepository : IQuestionTypeRepository
    {
        public QuestionType Get(int id)
        {
            using (var context = new SuerveyDbContext())
            {
                return context.QuetionTypes.SingleOrDefault(qt => qt.Id == id);
            }
        }

        public ICollection<QuestionType> GetAll()
        {
            using (var context = new SuerveyDbContext())
            {
                return context.QuetionTypes.ToList();
            }
        }
    }
}
