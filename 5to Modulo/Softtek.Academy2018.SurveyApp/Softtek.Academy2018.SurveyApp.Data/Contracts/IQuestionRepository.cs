using Softtek.Academy2018.SurveyApp.Domain.Model;
using System.Collections.Generic;

namespace Softtek.Academy2018.SurveyApp.Data.Contracts
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        bool questionInSurvey(int id);

        bool AddOptionToQuestion(int optionid, int questionid);

        bool RemoveOptionToQuestion(int optionid, int questionid);

        ICollection<Option> GetOptionByQuestion(int surveyid);
    }
}
