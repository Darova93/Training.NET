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
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly IQuestionTypeRepository _repository;

        public QuestionTypeService(IQuestionTypeRepository repository)
        {
            _repository = repository;
        }

        public QuestionType Get(int id)
        {
            return _repository.Get(id);
        }

        public ICollection<QuestionType> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
