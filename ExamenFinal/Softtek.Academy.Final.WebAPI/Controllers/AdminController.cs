using Softtek.Academy.Final.Business.Contracts;
using Softtek.Academy.Final.Domain.Model;
using Softtek.Academy.Final.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Softtek.Academy.Final.WebAPI.Controllers
{
    [RoutePrefix("admin/survey")]
    public class AdminController : ApiController
    {
        private readonly ISurveyService _surveyService;
        private readonly IQuestionService _questionService;

        public AdminController(ISurveyService surveyService, IQuestionService questionService)
        {
            _surveyService = surveyService;
            _questionService = questionService;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = _surveyService.GetAll();

            List<SurveyDTO> surveyDTO = result.Select(s => new SurveyDTO
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                Status = s.Status,
                IsActive = s.IsActive

            }).ToList();

            return Ok(surveyDTO);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            var result = _surveyService.Get(id);

            if (result == null) return NotFound();

            SurveyDTO surveyDTO = new SurveyDTO
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                Status = result.Status,
                IsActive = result.IsActive
            };

            return Ok(surveyDTO);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] SurveyDTO surveyDTO)
        {
            if (surveyDTO == null) return BadRequest("Request is null");

            Survey survey = new Survey
            {
                Title = surveyDTO.Title,
                Description = surveyDTO.Description
            };

            var result = _surveyService.Create(survey);

            if (result <= 0) return BadRequest("Unable to create survey");

            var payload = new
            {
                SurveyId = result
            };

            return Ok(payload);
        }

        [Route("{id:int}")]
        [HttpPut]
        public IHttpActionResult Update([FromUri] int id, [FromBody] SurveyDTO surveyDTO)
        {
            if (surveyDTO == null) return BadRequest("Request is null");

            Survey survey = new Survey
            {
                Id = id,
                Title = surveyDTO.Title,
                Description = surveyDTO.Description
            };

            var result = _surveyService.Update(survey);

            if (result == false) return BadRequest("Unable to update survey");

            return Ok("Survey updated!");
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            if (id <= 0) return BadRequest("Request is null");

            var result = _surveyService.Delete(id);

            if (result == false) return BadRequest("Unable to delete survey");

            return Ok("Survey deleted!");
        }

        [Route("{id:int}/activate")]
        [HttpPut]
        public IHttpActionResult Activate([FromUri] int id)
        {
            if (id <= 0) return BadRequest("Request is null");

            var result = _surveyService.Activate(id);

            if (result == false) return BadRequest("Unable to activate survey");

            return Ok("Survey activated!");
        }

        [Route("{id:int}/deactivate")]
        [HttpPut]
        public IHttpActionResult DeActivate([FromUri] int id)
        {
            if (id <= 0) return BadRequest("Request is null");

            var result = _surveyService.DeActivate(id);

            if (result == false) return BadRequest("Unable to deactivate survey");

            return Ok("Survey deactivated!");
        }

        [Route("{id:int}/status")]
        [HttpPut]
        public IHttpActionResult ChangeStatus([FromUri] int id, [FromBody] SurveyDTO survey)
        {
            if (id <= 0) return BadRequest("Request is null");

            var status = survey.Status;

            var result = _surveyService.ChangeStatus(id, status);

            if (result == false) return BadRequest("Unable to change survey status");

            return Ok($"Survey status changed to {status.ToString()}!");
        }

        [Route("{surveyid:int}/add")]
        [HttpPut]
        public IHttpActionResult AddQuestion([FromUri] int surveyid, [FromBody] QuestionDTO question)
        {
            if (question == null) return BadRequest("Request is null");

            if (surveyid <= 0 || question.Id <= 0) return BadRequest("Request is null");

            var result = _surveyService.AddQuestionToSurvey(question.Id, surveyid);

            if (result == false) return BadRequest("Unable to assign question to survey!");

            return Ok("Question added to survey!");
        }

        [Route("{surveyid:int}/remove")]
        [HttpPut]
        public IHttpActionResult RemoveQuestion([FromUri] int surveyid, [FromBody] QuestionDTO question)
        {
            var questionid = question.Id;

            if (surveyid <= 0 || questionid <= 0) return BadRequest("Request is null");

            var result = _surveyService.RemoveQuestionFromSurvey(questionid, surveyid);

            if (result == false) return BadRequest("Unable to remove question from survey!");

            return Ok("Question removed from survey!");
        }

        [Route("{surveyid:int}/questions")]
        [HttpGet]
        public IHttpActionResult SurveyQuestions([FromUri] int surveyid)
        {
            if (surveyid <= 0) return BadRequest("Request is null");

            var result = _surveyService.GetSurveyQuestions(surveyid);

            List<QuestionDTO> questionDTO = result.Select(q => new QuestionDTO
            {
                Id = q.Id,
                Text = q.Text,
                QuestionTypeId = q.QuestionTypeId

            }).ToList();

            return Ok(questionDTO);
        }

        [Route("{surveyid:int}/questionsnot")]
        [HttpGet]
        public IHttpActionResult NotSurveyQuestions(int surveyid)
        {
            if (surveyid <= 0) return BadRequest("Request is null");

            var result = _surveyService.GetNotSurveyQuestions(surveyid);

            List<QuestionDTO> questionDTO = result.Select(q => new QuestionDTO
            {
                Id = q.Id,
                Text = q.Text,
                QuestionTypeId = q.QuestionTypeId

            }).ToList();

            return Ok(questionDTO);
        }

        [Route("report")]
        [HttpGet]
        public IHttpActionResult Report()
        {
            var surveys = _surveyService.GetAll();

            List<AdminReport> adminReport = new List<AdminReport>();

            foreach (var survey in surveys)
            {
                var result = _surveyService.Report(survey.Id);

                if (result != null)
                {
                    adminReport.Add(new AdminReport
                    {
                        Title = survey.Title,
                        Description = survey.Description,
                        Results = result
                    });
                }
            }

            return Ok(adminReport);
        }

    }
}
