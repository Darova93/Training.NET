using Softtek.Academy.Final.Domain.Model;
using System.Collections.Generic;

namespace Softtek.Academy.Final.Data.Contracts
{
    public interface ISurveyRepository : IGenericRepository<Survey>
    {
        int Create(Survey survey);

        bool Update(Survey survey);

        bool Delete(int id);

        bool Activate(int id);

        bool DeActivate(int id);

        bool ChangeStatus(int id, Status status);

        bool AddQuestionToSurvey(int questionid, int surveyid);

        bool RemoveQuestionFromSurvey(int questionid, int surveyid);

        ICollection<Answer> GetSurveyAnswers(int id);

        ICollection<Question> GetSurveyQuestions(int id);

        ICollection<Question> GetNotSurveyQuestions(int id);

        bool SurveyExists(int id);

        bool UserSurveyExists(Answer answer);

        bool HasOpenValue(int id);

        ICollection<SurveyReport> Report(int id);
    }
}
