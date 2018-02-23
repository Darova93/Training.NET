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
    [RoutePrefix("api/Survey")]
    public class SurveyController : ApiController
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService service)
        {
            _surveyService = service;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] SurveyDTO surveyDTO)
        {
            if (surveyDTO == null) return BadRequest("Survey is null");

            Survey survey = new Survey
            {
                Title = surveyDTO.Title,
                Description = surveyDTO.Description
            };

            int id = _surveyService.Add(survey);

            if (id <= 0)
            {
                return BadRequest("Unable to create survey");
            }

            var payload = new { SurveyId = id };

            return Ok();
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            var survey = _surveyService.Get(id);

            if (survey == null) return NotFound();

            SurveyDTO surveyDTO = new SurveyDTO
            {
                Title = survey.Title,    
                Description = survey.Description
            };

            return Ok(surveyDTO);
        }
    }
}
