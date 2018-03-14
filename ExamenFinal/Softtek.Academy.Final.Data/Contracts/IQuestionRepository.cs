using Softtek.Academy.Final.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy.Final.Data.Contracts
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        bool AddQuestionToSurvey(int questionid, int surveyid);

        bool RemoveQuestionFromSurvey(int questionid, int surveyid);

        ICollection<Question> GetSurveyQuestions(int surveyid);
    }
}
