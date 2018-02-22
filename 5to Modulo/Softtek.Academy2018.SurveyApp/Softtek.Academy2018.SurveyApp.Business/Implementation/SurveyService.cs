using Softtek.Academy2018.SurveyApp.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.SurveyApp.Domain.Model;
using Softtek.Academy2018.SurveyApp.Data.Contracts;

namespace Softtek.Academy2018.SurveyApp.Business.Implementation
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _repository;

        public SurveyService(ISurveyRepository repository)
        {
            _repository = repository;
        }

        public int Add(Survey item)
        {
            if (item == null) return 0;

            if (string.IsNullOrEmpty(item.Title) || string.IsNullOrEmpty(item.Description)) return 0;

            if (item.Title.Count() > 200 || item.Description.Count() > 500) return 0;

            int id = _repository.Add(item);

            return id;
        }

        public bool Delete(Survey item)
        {
            if (item == null) return false;

            var findsurveyid = _repository.Get(item.Id);
            if (findsurveyid == null) return false;

            bool result = _repository.Delete(item);

            return result;
        }

        public Survey Get(int id)
        {
            if (id <= 0) return null;

            return _repository.Get(id);
        }

        public bool Update(Survey item)
        {
            if (item == null) return false;

            if (string.IsNullOrEmpty(item.Title) || string.IsNullOrEmpty(item.Description)) return false;

            if (item.Title.Count() > 200 || item.Description.Count() > 500) return false;

            bool result = _repository.Update(item);

            return result;
        }
    }
}
