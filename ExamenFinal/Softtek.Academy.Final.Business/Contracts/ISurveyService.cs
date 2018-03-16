using Softtek.Academy.Final.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy.Final.Business.Contracts
{
    public interface ISurveyService : IGenericService<Survey>
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

        Survey GetUserSurvey(int id);

        ICollection<Survey> GetUserSurveys();

        ICollection<SurveyReport> Report(int id);
    }
}
