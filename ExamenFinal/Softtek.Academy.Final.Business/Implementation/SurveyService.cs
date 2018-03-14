using Softtek.Academy.Final.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy.Final.Domain.Model;
using Softtek.Academy.Final.Data.Contracts;

namespace Softtek.Academy.Final.Business.Implementation
{
    public class SurveyService : ISurveyService
    {

        private readonly ISurveyRepository _repository;
        private readonly IAnswerRepository _ansrepository;

        public SurveyService(ISurveyRepository repository, IAnswerRepository ansrepository)
        {
            _repository = repository;
            _ansrepository = ansrepository;
        }

        public bool Archive(int id)
        {
            if (id <= 0) return false;

            if (!_repository.SurveyExists(id)) return false;

            bool result = _repository.Archive(id);

            return result;
        }

        public bool ChangeStatus(int id, Status status)
        {
            if (id <= 0) return false;

            Survey survey = _repository.Get(id);
            if (survey == null) return false;

            switch (survey.Status)
            {
                case Status.Cancel:
                    return false;

                case Status.Done:
                    return false;

                case Status.Draft:
                    if (status == Status.Ready)
                    {
                        return _repository.ChangeStatus(id, status);
                    }
                    break;
                case Status.Ready:
                    if (status == Status.Done || status == Status.Cancel)
                    {
                        return _repository.ChangeStatus(id, status);
                    }
                    else if (status == Status.Draft || _ansrepository.GetSurveyAnswers(id) == null)
                    {
                        return _repository.ChangeStatus(id, status);
                    }
                    break;
            }

            return false;
        }

        public int Create(Survey survey)
        {
            if (survey == null) return 0;

            if (survey.Title == null || survey.Description == null) return 0;

            int newid = _repository.Create(survey);

            return newid;
        }

        public Survey Get(int id)
        {
            if (id <= 0) return null;

            return _repository.Get(id);
        }

        public ICollection<Survey> GetAll()
        {
            return _repository.GetAll();
        }

        public ICollection<Survey> GetAvailableSurveys()
        {
            var surveys = GetReadySurveys();

            return surveys.Where(s => s.IsActive == true).ToList();
        }

        public ICollection<Survey> GetReadySurveys()
        {
            var surveys = _repository.GetAll();

            return surveys.Where(s => s.Status == Status.Ready).ToList();
        }

        public bool Restore(int id)
        {
            if (id <= 0) return false;

            if (!_repository.SurveyExists(id)) return false;

            bool result = _repository.Restore(id);

            return result;
        }

        public bool Update(Survey survey)
        {
            if (survey == null) return false;

            if (survey.Id <= 0) return false;

            var oldsurvey = _repository.Get(survey.Id);
            if (oldsurvey.Status != Status.Draft) return false;

            bool result = _repository.Update(survey);

            return result;
        }
    }
}
