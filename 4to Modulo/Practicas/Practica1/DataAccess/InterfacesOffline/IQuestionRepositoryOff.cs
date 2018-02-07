using DataAccess.DTO;
using System.Collections.Generic;

namespace DataAccess.InterfacesOffline
{
    public interface IQuestionRepositoryOff
    {
        List<QuestionDTO> GetAll();

        QuestionDTO GetById(int entityId);

        void Add(QuestionDTO entity);

        void Update(QuestionDTO entity);

        void Delete(int entityId);

        int CountQuestion();
    }
}
