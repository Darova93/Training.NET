using Softtek.Academy.Final.Domain.Model;
using System.Collections.Generic;

namespace Softtek.Academy.Final.Data.Contracts
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        ICollection<Option> GetQuestionOptions(int id);

        bool SurveyHasQuestion(int questionid, int surveyid);

        bool QuestionExists(int id);
    }
}
