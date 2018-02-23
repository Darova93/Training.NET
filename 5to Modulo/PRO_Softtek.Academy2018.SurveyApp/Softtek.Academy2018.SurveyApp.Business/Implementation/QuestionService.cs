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
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;
        private readonly IQuestionTypeRepository _qtrepository;

        public QuestionService(IQuestionRepository repository, IQuestionTypeRepository qtrepository)
        {
            _repository = repository;
            _qtrepository = qtrepository;
        }

        public int Add(Question item)
        {
            if (string.IsNullOrEmpty(item.Text)) return 0;
            if (item.Text.Count() > 300) return 0;

            var questionType = _qtrepository.Get(item.QuestionTypeId);
            if (questionType == null) return 0;

            int id = _repository.Add(item);

            return id;
        }

        public bool Delete(Question item)
        {
            if (item == null) return false;

            var findquestionid = _repository.Get(item.Id);
            if (findquestionid == null) return false;

            bool questionInSurvey = _repository.questionInSurvey(item.Id);
            if (questionInSurvey) return false;

            bool result = _repository.Delete(item);

            return result;
        }

        public Question Get(int id)
        {
            if (id <= 0) return null;

            return _repository.Get(id);
        }

        public bool Update(Question item)
        {
            if (item == null) return false;

            if (string.IsNullOrEmpty(item.Text)) return false;

            if (item.Text.Count() > 300) return false;

            var questionType = _qtrepository.Get(item.QuestionTypeId);
            if (questionType == null) return false;

            Question idExists = _repository.Get(item.Id);
            if (idExists == null) return false;

            bool questionInSurvey = _repository.questionInSurvey(item.Id);
            if (questionInSurvey) return false;

            bool result = _repository.Update(item);

            return result;
        }
    }
}
