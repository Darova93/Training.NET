using DataAccess.DTO;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IAnswerRepository
    {
        List<AnswerDTO> GetAll();

        AnswerDTO GetById(int entityId);

        void Add(AnswerDTO entity);

        void Update(AnswerDTO entity);

        void Delete(int entityId);

        int CountAnswer();
    }
}
