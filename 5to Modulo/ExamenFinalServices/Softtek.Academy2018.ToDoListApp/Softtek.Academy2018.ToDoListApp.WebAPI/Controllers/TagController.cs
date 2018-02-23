using Softtek.Academy2018.ToDoListApp.Business.Contracts;
using Softtek.Academy2018.ToDoListApp.Domain.Model;
using Softtek.Academy2018.ToDoListApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Softtek.Academy2018.ToDoListApp.WebAPI.Controllers
{
    [RoutePrefix("api/tag")]
    public class TagController : ApiController
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] TagDTO tagDTO)
        {
            if (tagDTO == null) return BadRequest("Request is null");

            Tag tag = new Tag
            {
                Name = tagDTO.Name
            };

            var result = _tagService.Create(tag);

            if (result <= 0) return BadRequest("Unable to create tag");

            var payload = new
            {
                TagID = result
            };

            return Ok(payload);
        }

        [Route("tasks/{id:int}")]
        [HttpGet]
        public IHttpActionResult CountItems([FromUri] int id)
        {
            if (id <= 0) return BadRequest("Request is invalid");

            int tasks = _tagService.CountItems(id);

            var payload = new
            {
                TasksAssigned = tasks
            };

            return Ok(payload);
        }

        [Route("archive/{id:int}")]
        [HttpDelete]
        public IHttpActionResult ArchiveTag([FromUri] int id)
        {
            if (id <= 0) return BadRequest("Request is invalid");

            var result = _tagService.Delete(id);

            if (!result) return BadRequest("Unable to archive tag");

            return Ok("Tag archived");
        }
    }
}
