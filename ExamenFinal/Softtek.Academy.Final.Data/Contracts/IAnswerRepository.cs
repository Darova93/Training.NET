using Softtek.Academy.Final.Domain.Model;

namespace Softtek.Academy.Final.Data.Contracts
{
    public interface IAnswerRepository : IGenericRepository<Answer>
    {
        int Create(Answer answer);
    }
}
