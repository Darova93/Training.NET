using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.DTO;
using DataAccess.Helpers;
using DataAccess.Entities;

namespace DataAccess.Implementation
{
    public class StudentEF : IStudentRepository
    {
        public void AddStudent(StudentDTO entity)
        {
            Student student = DataConverter.ConvertStudentDTOtoEntity(entity);
            using (var context = new DemoContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public List<StudentDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public StudentDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int StudentCount()
        {
            using(var context = new DemoContext())
            {
                return 4;
            }
        }

        public void UpdateStudent(StudentDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
