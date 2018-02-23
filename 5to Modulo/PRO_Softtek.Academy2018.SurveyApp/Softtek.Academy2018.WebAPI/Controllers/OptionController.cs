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
    [RoutePrefix("api/Option")]
    public class OptionController : ApiController
    {
        private readonly IOptionService _optionService;

        public OptionController(IOptionService service)
        {
            _optionService = service;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] OptionDTO optionDTO)
        {
            if (optionDTO == null) return BadRequest("Option is null");

            Option option = new Option
            {
                Text = optionDTO.Text
            };

            int id = _optionService.Add(option);

            if (id <= 0)
            {
                return BadRequest("Unable to create option");
            }

            var payload = new { OptionId = id };

            return Ok();
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            var option = _optionService.Get(id);

            if (option == null) return NotFound();

            OptionDTO optionDTO = new OptionDTO
            {
                Text = option.Text
            };

            return Ok(option);
        }
    }
}
