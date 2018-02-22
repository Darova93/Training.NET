using Softtek.Academy2018.SurveyApp.Business.Contracts;
using Softtek.Academy2018.SurveyApp.Domain.Model;
using Softtek.Academy2018.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Softtek.Academy2018.WebAPI.Controllers
{
    [RoutePrefix("api/Question")]
    public class QuestionController : ApiController
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService service)
        {
            _questionService = service;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] QuestionDTO questionDTO)
        {
            if (questionDTO == null) return BadRequest("Question is null");

            Question question = new Question
            {
                Text = questionDTO.Text,
                QuestionTypeId = questionDTO.QuestionTypeId
            };

            int id = _questionService.Add(question);

            if (id <= 0)
            {
                return BadRequest("Unable to create question");
            }

            var payload = new { QuestionId = id };

            return Ok();
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            var question = _questionService.Get(id);

            if (question == null) return NotFound();

            QuestionDTO questionDTO = new QuestionDTO
            {
                Text = question.Text,
                QuestionTypeId = question.QuestionTypeId
            };

            return Ok(questionDTO);
        }
    }
}
