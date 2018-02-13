using DTO.DTO;
using System.Collections.Generic;

namespace Interfaces.Interfaces
{
    public interface ITeacherRepository
    {
        void Add(TeacherDTO entity);

        void Delete(int id);

        void Update(TeacherDTO entity);

        int Count();

        List<TeacherDTO> GetAll();

        TeacherDTO GetById(int id);
    }
}
