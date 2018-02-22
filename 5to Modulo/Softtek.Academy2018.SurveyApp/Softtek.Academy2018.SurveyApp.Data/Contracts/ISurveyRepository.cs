using Softtek.Academy2018.SurveyApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.SurveyApp.Data.Contracts
{
    public interface ISurveyRepository : IGenericRepository<Survey>
    {
        bool AddQuestionToSurvey(int surveyid, int questionid);

        bool RemoveQuestionToSurvey(int surveyid, int questionid);

        ICollection<Question> GetQuestionBySurvey(int surveyid);
    }
}
