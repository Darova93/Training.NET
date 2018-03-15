using Softtek.Academy.Final.Business.Contracts;
using Softtek.Academy.Final.Domain.Model;
using Softtek.Academy.Final.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Softtek.Academy.Final.WebAPI.Controllers
{
    [RoutePrefix("guest/survey")]
    public class UserController : ApiController
    {
        private readonly ISurveyService _surveyService;
        private readonly IAnswerService _answerService;

        public UserController(ISurveyService surveyService, IAnswerService answerService)
        {
            _surveyService = surveyService;
            _answerService = answerService;
        }

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
                Status = s.Status,
                IsActive = s.IsActive

            }).ToList();

            return Ok(result);
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
            };

            return Ok(result);
        }

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
    }
}
