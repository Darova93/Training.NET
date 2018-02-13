using DTO.DTO;
using System.Collections.Generic;

namespace Interfaces.Interfaces
{
    public interface IClassRepository
    {
        void Add(ClassDTO entity);

        void Delete(int id);

        void Update(ClassDTO entity);

        int Count();

        List<ClassDTO> GetAll();

        ClassDTO GetById(int id);
    }
}
