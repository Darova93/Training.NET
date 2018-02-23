using Softtek.Academy2018.SurveyApp.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.SurveyApp.Domain.Model;
using Softtek.Academy2018.SurveyApp.Data.Contracts;

namespace Softtek.Academy2018.SurveyApp.Business.Implementation
{
    public class SurveyQuestionService : ISurveyQuestionService
    {
        private readonly ISurveyRepository _repository;

        public SurveyQuestionService(ISurveyRepository repository)
        {
            _repository = repository;
        }

        public bool AddQuestionToSurvey(int surveyid, int questionid)
        {
            return _repository.AddQuestionToSurvey(surveyid, questionid);
        }

        public ICollection<Question> GetQuestionBySurvey(int surveyid)
        {
            return _repository.GetQuestionBySurvey(surveyid);
        }

        public bool RemoveQuestionToSurvey(int surveyid, int questionid)
        {
            return _repository.RemoveQuestionToSurvey(surveyid, questionid);
        }
    }
}
