using Softtek.Academy.Final.Business.Contracts;
using Softtek.Academy.Final.Domain.Model;
using Softtek.Academy.Final.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Softtek.Academy.Final.WebAPI.Controllers
{
    [RoutePrefix("guest/survey")]
    public class UserController : ApiController
    {
        private readonly ISurveyService _surveyService;
        private readonly IAnswerService _answerService;
        private readonly IQuestionService _questionService;

        public UserController(ISurveyService surveyService, IAnswerService answerService, IQuestionService questionService)
        {
            _surveyService = surveyService;
            _answerService = answerService;
            _questionService = questionService;
        }

        [EnableCors(origins: "http://127.0.0.1:5500", headers: "*", methods: "*")]
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = _surveyService.GetUserSurveys();

            List<SurveyDTO> surveyDTO = result.Select(s => new SurveyDTO
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                IsActive = s.IsActive,
                Status = s.Status

            }).ToList();

            return Ok(surveyDTO);
        }

        [EnableCors(origins: "http://127.0.0.1:5500", headers: "*", methods: "*")]
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            var result = _surveyService.GetUserSurvey(id);

            if (result == null) return NotFound();

            SurveyDTO surveyDTO = new SurveyDTO
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                IsActive = result.IsActive,
                Status = result.Status
            };

            return Ok(surveyDTO);
        }

        [EnableCors(origins: "http://127.0.0.1:5500", headers: "*", methods: "*")]
        [Route("{id:int}")]
        [HttpPost]
        public IHttpActionResult Create([FromUri] int id, [FromBody] AnswerDTO answerDTO)
        {
            if (answerDTO == null) return BadRequest("Request is null");

            Answer answer = new Answer
            {
                SurveyId = id,
                QuestionId = answerDTO.QuestionId,
                OpenText = answerDTO.OpenText,
                OptionId = answerDTO.OptionId,
                Guest = answerDTO.Guest
            };

            var result = _answerService.CreateAnswer(answer);

            if (result <= 0) return BadRequest("Unable to register your answer");

            var payload = new
            {
                AnswerId = result
            };

            return Ok(payload);
        }

        [EnableCors(origins: "http://127.0.0.1:5500", headers: "*", methods: "*")]
        [Route("{id:int}/questions")]
        [HttpGet]
        public IHttpActionResult GetSurveyQuestions([FromUri] int id)
        {
            var result = _surveyService.GetUserSurvey(id);

            if (result == null) return NotFound();

            var getquestions = _surveyService.GetSurveyUserQuestions(id);

            List<QuestionDTO> questionswithoptions = new List<QuestionDTO>();

            foreach (var question in getquestions)
            {
                var getoptions = _questionService.GetQuestionsOptions(question.Id);
                List<OptionDTO> getoptionsDTO = getoptions.Select(o => new OptionDTO
                {
                    Id = o.Id,
                    Text = o.Text

                }).ToList();

                QuestionDTO newquestion = new QuestionDTO {
                    Id = question.Id,
                    Text = question.Text,
                    QuestionTypeId = question.QuestionTypeId,
                    Options = getoptionsDTO
                };

                questionswithoptions.Add(newquestion);

            }

            return Ok(questionswithoptions);
        }

    }
}
