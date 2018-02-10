using DataAccessEF.Entities;
using DataAccessEF.Helpers;
using DTO.DTO;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessEF.Implementation
{
    public class OptionEF : IOptionRepository
    {
        public void Add(OptionDTO entity)
        {
            Option result = DataConverter.OptionDTOToEntity(entity);
            using (var context = new DemoContext())
            {
                context.Options.Add(result);
                context.SaveChanges();
            }
        }

        public int CountOption()
        {
            int count = 0;
            using (var context = new DemoContext())
            {
                count = context.Options.Count();
            }
            return count;
        }

        public void Delete(int entityId)
        {
            using(var context = new DemoContext())
            {
                var option = context.Options.Find(entityId);
                context.Options.Remove(option);
                context.SaveChanges();
            }
        }

        public List<OptionDTO> GetAll()
        {
            List<OptionDTO> result = new List<OptionDTO>(); 
            using (var context = new DemoContext())
            {
                result = context.Options
                    .Select(s => new OptionDTO
                    {
                        Text = s.Text,
                        OptionId = s.OptionId
                    })
                    .ToList();
            }
            return result;
        }

        public OptionDTO GetById(int entityId)
        {
            using (var context = new DemoContext())
            {
                var entity = context.Options.Find(entityId);
                var entityDTO = DataConverter.OptionEntityToDTO(entity);
                return entityDTO;
            }
        }

        public void Update(OptionDTO entity)
        {
            Option result = DataConverter.OptionDTOToEntity(entity);

            using (var context = new DemoContext())
            {
                var found = context.Options.Find(result.OptionId);
                found.Text = entity.Text;
                found.ModifiedDate = DateTime.Now;
                context.SaveChanges();
            }
        }

        public List<OptionDTO> GetOptionsByQuestionId(int entityId)
        {
            List<OptionDTO> optionDTO = new List<OptionDTO>();
            using (var context = new DemoContext())
            {
                var query = from s in context.Options
                            where s.Questions.Any(e => e.QuestionId == entityId)
                            select s;
                var result = query.ToList();

                var query2 = context.Questions.Where(q => q.QuestionId == entityId).SelectMany(o => o.Option);

                var result2 = query2.ToList();
            }
            return optionDTO;
        }
    }
}
