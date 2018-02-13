using DTO.DTO;
using System.Collections.Generic;

namespace Interfaces.Interfaces
{
    public interface ISubjectRepository
    {
        void Add(SubjectDTO entity);

        void Delete(int id);

        void Update(SubjectDTO entity);

        int Count();

        List<SubjectDTO> GetAll();

        SubjectDTO GetById(int id);
    }
}
