using DTO.DTO;
using System.Collections.Generic;

namespace Interfaces.Interfaces
{
    public interface IQuestionTypeRepository
    {
        List<QuestionTypeDTO> GetAll();

        QuestionTypeDTO GetById(int entityId);

        void Add(QuestionTypeDTO entity);

        void Update(QuestionTypeDTO entity);

        void Delete(int entityId);

        int CountQuestionType();
    }
}
