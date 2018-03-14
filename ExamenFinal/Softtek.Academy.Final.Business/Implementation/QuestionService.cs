using Softtek.Academy.Final.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy.Final.Domain.Model;

namespace Softtek.Academy.Final.Business.Implementation
{
    public class QuestionService : IQuestionService
    {
        public bool AddQuestionToSurvey(int questionid, int surveyid)
        {
            throw new NotImplementedException();
        }

        public Question Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool RemoveQuestionFromSurvey(int questionid, int surveyid)
        {
            throw new NotImplementedException();
        }
    }
}
