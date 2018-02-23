using Softtek.Academy2018.SurveyApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.SurveyApp.Domain.Model;

namespace Softtek.Academy2018.SurveyApp.Data.Implementations
{
    public class OptionDataRepository : IOptionRepository
    {
        public int Add(Option option)
        {
            using (var context = new SuerveyDbContext())
            {
                option.CreatedDate = DateTime.Now;

                context.Options.Add(option);
                context.SaveChanges();

                return option.Id;
            }
        }

        public bool Delete(Option option)
        {
            using (var context = new SuerveyDbContext())
            {
                Option currentoption = context.Options.SingleOrDefault(o => o.Id == option.Id);

                if (currentoption == null) return false;

                context.Options.Remove(currentoption);
                context.SaveChanges();
                
                return true;
            }
        }

        public Option Get(int id)
        {
            using (var context = new SuerveyDbContext())
            {
                return context.Options.SingleOrDefault(s => s.Id == id);
            }
        }

        public bool optionExists(string text)
        {
            using (var context = new SuerveyDbContext())
            {
                return context.Options.Any(o => o.Text.ToLower() == text.ToLower());
            }
        }

        public bool optionIsAssigned(int id)
        {
            using (var context = new SuerveyDbContext())
            {
                return (context.Options.SingleOrDefault(o => o.Id == id).Questions.Count > 0);
            }
        }

        public bool Update(Option option)
        {
            using (var context = new SuerveyDbContext())
            {
                Option oldoption = context.Options.SingleOrDefault(o => o.Id == option.Id);

                if (oldoption == null) return false;

                oldoption.Text = option.Text;
                oldoption.ModifiedDate = DateTime.Now;
                context.SaveChanges();

                return true;
            }
        }
    }
}
