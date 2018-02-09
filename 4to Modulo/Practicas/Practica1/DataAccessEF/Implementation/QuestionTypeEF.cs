using DataAccessEF.Entities;
using DataAccessEF.Helpers;
using DTO.DTO;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessEF.Implementation
{
    public class QuestionTypeEF : IQuestionTypeRepository
    {
        public void Add(QuestionTypeDTO entity)
        {
            QuestionType result = DataConverter.QuestionTypeDTOToEntity(entity);
            using (var context = new DemoContext())
            {
                context.QuestionTypes.Add(result);
                context.SaveChanges();
            }
        }

        public int CountQuestionType()
        {
            int count = 0;
            using (var context = new DemoContext())
            {
                count = context.QuestionTypes.Count();
            }
            return count;
        }

        public void Delete(int entityId)
        {
            using(var context = new DemoContext())
            {
                var questionType = context.QuestionTypes.Find(entityId);
                context.QuestionTypes.Remove(questionType);
                context.SaveChanges();
            }
        }

        public List<QuestionTypeDTO> GetAll()
        {
            List<QuestionTypeDTO> result = new List<QuestionTypeDTO>(); 
            using (var context = new DemoContext())
            {
                result = context.QuestionTypes
                    .Select(s => new QuestionTypeDTO
                    {
                        Description = s.Description,
                        QuestionTypeId = s.QuestionTypeId
                    })
                    .ToList();
            }
            return result;
        }

        public QuestionTypeDTO GetById(int entityId)
        {
            using (var context = new DemoContext())
            {
                var entity = context.QuestionTypes.Find(entityId);
                var entityDTO = DataConverter.QuestionTypeEntityToDTO(entity);
                return entityDTO;
            }
        }

        public void Update(QuestionTypeDTO entity)
        {
            QuestionType result = DataConverter.QuestionTypeDTOToEntity(entity);

            using (var context = new DemoContext())
            {
                var found = context.QuestionTypes.Find(result.QuestionTypeId);
                found.Description = entity.Description;
                context.SaveChanges();
            }
        }
    }
}
