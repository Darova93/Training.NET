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
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _repository;

        public OptionService(IOptionRepository repository)
        {
            _repository = repository;
        }

        public int Add(Option item)
        {
            if (item == null) return 0;

            if (string.IsNullOrEmpty(item.Text)) return 0;

            if (item.Text.Count() > 500) return 0;

            bool optionExists = _repository.optionExists(item.Text);
            if (optionExists) return 0;

            int id = _repository.Add(item);

            return id;
        }

        public bool Delete(Option item)
        {
            if (item == null) return false;

            var findoptionid = _repository.Get(item.Id);
            if (findoptionid == null) return false;

            bool optionsIsAssigned = _repository.optionIsAssigned(item.Id);
            if (optionsIsAssigned) return false;

            bool result =_repository.Delete(item);

            return result;
        }

        public Option Get(int id)
        {
            if (id <= 0) return null;

            return _repository.Get(id);
        }

        public bool Update(Option item)
        {
            if (item == null) return false;

            if (string.IsNullOrEmpty(item.Text)) return false;

            if (item.Text.Count() > 500) return false;

            Option idExists = _repository.Get(item.Id);
            if (idExists == null) return false;

            bool optionExists = _repository.optionExists(item.Text);
            if (optionExists || item.Id!=idExists.Id) return false;

            bool optionsIsAssigned = _repository.optionIsAssigned(item.Id);
            if (optionsIsAssigned) return false;

            bool result = _repository.Update(item);

            return result;
        }
    }
}
