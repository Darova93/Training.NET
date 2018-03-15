using Softtek.Academy.Final.Business.Contracts;
using Softtek.Academy.Final.Domain.Model;
using Softtek.Academy.Final.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Softtek.Academy.Final.WebAPI.Controllers
{
    [RoutePrefix("admin/survey")]
    public class AdminController : ApiController
    {
        private readonly ISurveyService _surveyService;

        public AdminController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
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

        [Route("activate/{id:int}")]
        [HttpPut]
        public IHttpActionResult Activate([FromUri] int id)
        {
            if (id <= 0) return BadRequest("Request is null");

            var result = _surveyService.Activate(id);

            if (result == false) return BadRequest("Unable to activate survey");

            return Ok("Survey activated!");
        }

        [Route("deactivate/{id:int}")]
        [HttpPut]
        public IHttpActionResult DeActivate([FromUri] int id)
        {
            if (id <= 0) return BadRequest("Request is null");

            var result = _surveyService.DeActivate(id);

            if (result == false) return BadRequest("Unable to deactivate survey");

            return Ok("Survey deactivated!");
        }

        [Route("status/{id:int}")]
        [HttpPut]
        public IHttpActionResult ChangeStatus([FromUri] int id, [FromBody] Status status)
        {
            if (id <= 0) return BadRequest("Request is null");

            var result = _surveyService.ChangeStatus(id, status);

            if (result == false) return BadRequest("Unable to change survey status");

            return Ok($"Survey status changed to {nameof(status)}!");
        }

        [Route("add/{surveyid:int}")]
        [HttpPut]
        public IHttpActionResult AddQuestion([FromUri] int surveyid, [FromBody] int questionid)
        {
            if (surveyid <= 0 || questionid <= 0) return BadRequest("Request is null");

            var result = _surveyService.AddQuestionToSurvey(questionid, surveyid);

            if (result == false) return BadRequest("Unable to assign question to survey!");

            return Ok("Question added to survey!");
        }

        [Route("remove/{surveyid:int}")]
        [HttpPut]
        public IHttpActionResult RemoveQuestion([FromUri] int surveyid, [FromBody] int questionid)
        {
            if (surveyid <= 0 || questionid <= 0) return BadRequest("Request is null");

            var result = _surveyService.RemoveQuestionFromSurvey(questionid, surveyid);

            if (result == false) return BadRequest("Unable to remove question from survey!");

            return Ok("Question removed from survey!");
        }

        //[Route("{surveyid:int}/{questionid:int}")]
        //[HttpDelete]
        //public IHttpActionResult RemoveQuestion([FromUri] int surveyid, [FromUri] int questionid)
        //{
        //    if (surveyid <= 0 || questionid <= 0) return BadRequest("Request is null");

        //    var result = _surveyService.RemoveQuestionFromSurvey(questionid, surveyid);

        //    if (result == false) return BadRequest("Unable to remove question from survey!");

        //    return Ok("Question removed from survey!");
        //}


    }
}
