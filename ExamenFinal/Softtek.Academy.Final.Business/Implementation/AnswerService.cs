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
    public class AnswerService : IAnswerService
    {
        private readonly ISurveyRepository _survrepository;
        private readonly IQuestionRepository _quesrepository;
        private readonly IAnswerRepository _ansrepository;

        public AnswerService(IAnswerRepository ansrepository, ISurveyRepository survrepository, IQuestionRepository quesrepository)
        {
            _ansrepository = ansrepository;
            _survrepository = survrepository;
            _quesrepository = quesrepository;
        }

        public int CreateAnswer(Answer answer)
        {
            if (answer == null) return 0;

            if (answer.QuestionId <= 0 || answer.SurveyId <= 0) return 0;

            if (answer.OptionId == null && string.IsNullOrEmpty(answer.OpenText)) return 0;

            if (answer.OptionId != null && !string.IsNullOrEmpty(answer.OpenText)) return 0;

            Question question = _quesrepository.Get(answer.QuestionId);

            if(question.QuestionTypeId == 1 && string.IsNullOrEmpty(answer.OpenText))
            {
                return 0;
            }
            else if(question.QuestionTypeId == 1)
            {
                if (answer.OpenText.Length > 300) return 0;
            }

            if ((question.QuestionTypeId == 2 || question.QuestionTypeId == 3) && answer.OptionId==null)
            {
                return 0;
            }

            if (!string.IsNullOrEmpty(answer.Guest))
            {
                if (answer.Guest.Length > 100) return 0;
            }

            if (!_quesrepository.QuestionExists(answer.QuestionId)) return 0;

            if (!_survrepository.UserSurveyExists(answer)) return 0;

            int newid = _ansrepository.Create(answer);

            return newid;
        }

        public Answer Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Answer> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
