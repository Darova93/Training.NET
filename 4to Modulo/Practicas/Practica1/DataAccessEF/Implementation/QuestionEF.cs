using DataAccessEF.Entities;
using DataAccessEF.Helpers;
using DTO.DTO;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessEF.Implementation
{
    public class QuestionEF : IQuestionRepository
    {
        public void Add(QuestionDTO entity)
        {
            Question result = DataConverter.QuestionDTOToEntity(entity);
            using (var context = new DemoContext())
            {
                context.Questions.Add(result);
                context.SaveChanges();
            }
        }

        public int CountQuestion()
        {
            int count = 0;
            using (var context = new DemoContext())
            {
                count = context.Questions.Count();
            }
            return count;
        }

        public void Delete(int entityId)
        {
            using(var context = new DemoContext())
            {
                var question = context.Questions.Find(entityId);
                context.Questions.Remove(question);
                context.SaveChanges();
            }
        }

        public List<QuestionDTO> GetAll()
        {
            List<QuestionDTO> result = new List<QuestionDTO>(); 
            using (var context = new DemoContext())
            {
                result = context.Questions
                    .Select(s => new QuestionDTO
                    {
                        QuestionId = s.QuestionId,
                        Text = s.Text,
                        QuestionTypeId = s.QuestionTypeId
                    })
                    .ToList();
            }
            return result;
        }

        public QuestionDTO GetById(int entityId)
        {
            QuestionDTO fake = new QuestionDTO();
            //using (var context = new DemoContext())
            //{
            //    var entity = context.Questions.Find(entityId);
            //    var entityDTO = DataConverter.QuestionEntityToDTO(entity);
            //    return entityDTO;
            //}

            //Query(LINQ)
            using (var context = new DemoContext())
            {
                var result = from question in context.Questions
                             where question.QuestionId == entityId
                             select question;
                fake = DataConverter.QuestionEntityToDTO(result.FirstOrDefault());
                return fake;
            }

            //Forma Metodo
            //using (var context = new DemoContext())
            //{
            //    var result = context.Questions.Where(q => q.QuestionId == entityId).FirstOrDefault();
            //    QuestionDTO dtoObj = new QuestionDTO
            //        {
            //        IsActive = result.IsActive,
            //        IsRequired = result.IsRequired,
            //        Text = result.Text,
            //        CreateDate = result.CreateDate,
            //        ModifiedDate = result.ModifiedDate,
            //        QuestionTypeId = result.QuestionTypeId,
            //        QuestionId = result.QuestionId,
            //        QuestionType = new QuestionTypeDTO { Description = result.QuestionType.Description, QuestionTypeId = result.QuestionType.QuestionTypeId },
            //        Option = result.Option.ToList()
            //            .Select(opt => new OptionDTO
            //            {
            //                OptionId = opt.OptionId,
            //                Text = opt.Text
            //            }).ToList()
            //        };
            //}
            return fake;
        }

        public void Update(QuestionDTO entity)
        {
            Question result = DataConverter.QuestionDTOToEntity(entity);

            using (var context = new DemoContext())
            {
                var found = context.Questions.Find(result.QuestionId);
                found.Text = entity.Text;
                found.ModifiedDate = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}
