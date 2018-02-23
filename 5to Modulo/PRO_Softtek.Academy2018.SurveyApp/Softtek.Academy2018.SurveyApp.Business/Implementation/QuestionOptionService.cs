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
    public class QuestionOptionService : IQuestionOptionService
    {
        private readonly IQuestionRepository _repository;
        private readonly IQuestionTypeRepository _qtrepository;

        public QuestionOptionService(IQuestionRepository repository, IQuestionTypeRepository qtrepository)
        {
            _repository = repository;
            _qtrepository = qtrepository;
        }

        public bool AddOptionToQuestion(int optionid, int questionid)
        {
            return _repository.AddOptionToQuestion(optionid, questionid);
            
        }

        public ICollection<Option> GetOptionByQuestion(int questionid)
        {
            return _repository.GetOptionByQuestion(questionid);
        }

        public bool RemoveOptionToQuestion(int optionid, int questionid)
        {
            return _repository.RemoveOptionToQuestion(optionid, questionid);
        }
    }
}
