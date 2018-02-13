using DTO.DTO;
using System.Collections.Generic;

namespace Interfaces.Interfaces
{
    public interface IStudentRepository
    {
        void AddStudent(StudentDTO entity);

        void DeleteStudent(int id);

        void UpdateStudent(StudentDTO entity);

        int StudentCount();

        List<StudentDTO> GetAll();

        StudentDTO GetById(int id);
    }
}
