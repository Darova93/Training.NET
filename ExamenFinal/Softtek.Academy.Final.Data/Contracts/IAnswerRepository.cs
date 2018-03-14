using Softtek.Academy.Final.Domain.Model;
using System.Collections.Generic;

namespace Softtek.Academy.Final.Data.Contracts
{
    public interface IAnswerRepository : IGenericRepository<Answer>
    {
        ICollection<Answer> GetSurveyAnswers(int id);
    }
}
