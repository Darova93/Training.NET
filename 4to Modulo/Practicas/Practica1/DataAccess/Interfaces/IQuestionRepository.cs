using System.Collections.Generic;
using DataAccess.DTO;

namespace DataAccess.Interfaces
{
    public interface IQuestionRepository
    {

        List<QuestionDTO> GetAll();

        QuestionDTO GetById(int entityId);

        void Add(QuestionDTO entity);

        void Update(QuestionDTO entity);

        void Delete(int entityId);

        int CountQuestion();

    }
}
