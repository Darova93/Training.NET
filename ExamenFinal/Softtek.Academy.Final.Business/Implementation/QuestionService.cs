using Softtek.Academy.Final.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy.Final.Domain.Model;
using Softtek.Academy.Final.Data.Contracts;

namespace Softtek.Academy.Final.Business.Implementation
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;

        public QuestionService(IQuestionRepository repository)
        {
            _repository = repository;
           
        }

        public Question Get(int id)
        {
            if (id <= 0) return null;

            return _repository.Get(id);
        }

        public ICollection<Question> GetAll()
        {
            return _repository.GetAll();
        }

        public ICollection<Option> GetQuestionsOptions(int id)
        {
            if (id <= 0) return null;

            if (!_repository.QuestionExists(id)) return null;

            Question question = _repository.Get(id);

            return _repository.GetQuestionOptions(question.Id).ToList();
        }
    }
}
