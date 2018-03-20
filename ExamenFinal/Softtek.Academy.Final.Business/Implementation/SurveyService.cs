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
        private readonly IQuestionRepository _quesrepository;

        public SurveyService(ISurveyRepository repository, IQuestionRepository quesrepository)
        {
            _repository = repository;
            _quesrepository = quesrepository;
        }

        public int Create(Survey survey)
        {
            if (survey == null) return 0;

            if (survey.Title == null || survey.Description == null) return 0;

            if (survey.Title.Length > 50 || survey.Description.Length > 200) return 0;

            int newid = _repository.Create(survey);

            return newid;
        }

        public bool Update(Survey survey)
        {
            if (survey == null) return false;

            if (survey.Id <= 0) return false;

            if (survey.Title == null || survey.Description == null) return false;

            if (survey.Title.Length > 50 || survey.Description.Length > 200) return false;

            var oldsurvey = _repository.Get(survey.Id);
            if (oldsurvey.Status != Status.Draft) return false;

            bool result = _repository.Update(survey);

            return result;
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;

            if (!_repository.SurveyExists(id)) return false;

            bool result = _repository.Delete(id);

            return result;
        }

        public bool Activate(int id)
        {
            if (id <= 0) return false;

            if (!_repository.SurveyExists(id)) return false;

            bool result = _repository.Activate(id);

            return result;
        }

        public bool DeActivate(int id)
        {
            if (id <= 0) return false;

            if (!_repository.SurveyExists(id)) return false;

            bool result = _repository.DeActivate(id);

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
                        if (_repository.GetSurveyQuestions(id).Count() > 0)
                        {
                            return _repository.ChangeStatus(id, status);
                        }
                    }
                    break;
                case Status.Ready:
                    if (status == Status.Done || status == Status.Cancel)
                    {
                        return _repository.ChangeStatus(id, status);
                    }
                    else if (status == Status.Draft && _repository.GetSurveyAnswers(id).Count == 0)
                    {
                        return _repository.ChangeStatus(id, status);
                    }
                    break;
            }

            return false;
        }

        public bool AddQuestionToSurvey(int questionid, int surveyid)
        {
            if (questionid <= 0 || surveyid <= 0) return false;

            if (!_repository.SurveyExists(surveyid)) return false;

            if (!_quesrepository.QuestionExists(questionid)) return false;

            if (_repository.Get(surveyid).Status != Status.Draft) return false;

            if (_quesrepository.SurveyHasQuestion(questionid, surveyid)) return false;

            bool result = _repository.AddQuestionToSurvey(questionid, surveyid);

            return result;
        }

        public bool RemoveQuestionFromSurvey(int questionid, int surveyid)
        {
            if (questionid <= 0 || surveyid <= 0) return false;

            if (!_repository.SurveyExists(surveyid)) return false;

            if (!_quesrepository.QuestionExists(questionid)) return false;

            if (_repository.Get(surveyid).Status != Status.Draft) return false;

            if (!_quesrepository.SurveyHasQuestion(questionid, surveyid)) return false;

            bool result = _repository.RemoveQuestionFromSurvey(questionid, surveyid);

            return result;
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

        public ICollection<Question> GetSurveyUserQuestions(int id)
        {
            if (id <= 0) return null;

            if (!_repository.SurveyExists(id)) return null;

            Survey survey = _repository.Get(id);

            if (survey.IsActive == false || survey.Status != Status.Ready) return null;

            return _repository.GetSurveyQuestions(survey.Id).ToList();
        }

        public ICollection<Question> GetSurveyQuestions(int id)
        {
            if (id <= 0) return null;

            if (!_repository.SurveyExists(id)) return null;

            return _repository.GetSurveyQuestions(id);
        }

        public ICollection<Question> GetNotSurveyQuestions(int id)
        {
            if (id <= 0) return null;

            if (!_repository.SurveyExists(id)) return null;

            return _repository.GetNotSurveyQuestions(id);
        }

        public Survey GetUserSurvey(int id)
        {
            if (id <= 0) return null;

            if (!_repository.SurveyExists(id)) return null;

            Survey survey = _repository.Get(id);

            if (survey.IsActive == false || survey.Status != Status.Ready) return null;

            return survey;
        }

        public ICollection<Survey> GetUserSurveys()
        {
            var surveys = _repository.GetAll();

            return surveys.Where(s => s.Status != Status.Draft && s.IsActive == true).ToList();
        }

        public ICollection<SurveyReport> Report(int id)
        {
            if (id <= 0) return null;

            Survey survey = _repository.Get(id);

            bool result = _repository.HasOpenValue(id);
            if (result) return null;

            var answers = _repository.GetSurveyAnswers(id).Count();
            if (answers <= 0) return null;

            return _repository.Report(id);
        }

        
    }
}
