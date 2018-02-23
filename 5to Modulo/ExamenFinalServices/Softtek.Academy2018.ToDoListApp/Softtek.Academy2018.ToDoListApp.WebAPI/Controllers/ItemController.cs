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
    [RoutePrefix("api/task")]
    public class ItemController : ApiController
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] ItemDTO itemDTO)
        {
            if (itemDTO == null) return BadRequest("Request is null");

            Item item = new Item
            {
                Title = itemDTO.Title,
                Description = itemDTO.Description,
            };

            var result = _itemService.Create(item);

            if (result <= 0) return BadRequest("Unable to create task");

            var payload = new
            {
                ItemID = result
            };

            return Ok(payload);
        }

        [Route("assigntag/{itemid:int}/{tagid:int}")]
        [HttpPost]
        public IHttpActionResult AssignTag([FromUri] int itemid, [FromUri] int tagid)
        {
            if (itemid <= 0 || tagid <= 0) return BadRequest("Request is invalid");

            bool result = _itemService.AssignTask(itemid, tagid);

            if (!result) return BadRequest("Unable to assign tag");

            return Ok("Tag assigned to task");
        }

        [Route("assignstatus/{itemid:int}/{statusid:int}")]
        [HttpPost]
        public IHttpActionResult AssignStatus([FromUri] int itemid, [FromUri] int statusid)
        {
            if (itemid <= 0 || statusid <= 0) return BadRequest("Request is invalid");

            bool result = _itemService.AssignStatus(itemid, statusid);

            if (!result) return BadRequest("Unable to assign status");

            return Ok("Status assigned to task");
        }

        [Route("assignduedate")]
        [HttpPost]
        public IHttpActionResult AssignDueDate([FromBody] ItemDTO itemDTO)
        {
            if (itemDTO.Id <= 0 || itemDTO.DueDate == null) return BadRequest("Request is invalid");
            
            bool result = _itemService.AssignDueDate(itemDTO.DueDate, itemDTO.Id);

            if (!result) return BadRequest("Unable to assign that due date");

            return Ok("Task due date updated");
        }

        [Route("assignpriority/{itemid:int}/{priorityid:int}")]
        [HttpPost]
        public IHttpActionResult AssignPriority([FromUri] int itemid, [FromUri] int priorityid)
        {
            if (itemid <= 0 || priorityid <= 0) return BadRequest("Request is invalid");

            bool result = _itemService.AssignPriority(itemid, priorityid);

            if (!result) return BadRequest("Unable to assign priority");

            return Ok("Task priority updated");
        }

        [Route("getbypriority")]
        [HttpGet]
        public IHttpActionResult GetByPriority()
        {
            var result = _itemService.GetByPriority();

            if (result == null) return BadRequest("No tasks in list");

            List<ItemDTO> itemDTO = result.Select(q => new ItemDTO
            {
                Id = q.Id,
                PriorityId = q.PriorityId,
                Title = q.Title,
                Description = q.Description,
                StatusId = q.StatusId,
            }).ToList();

            return Ok(itemDTO);
        }

        [Route("getbystatus")]
        [HttpGet]
        public IHttpActionResult GetByStatus()
        {
            var result = _itemService.GetByStatus();

            if (result == null) return BadRequest("No tasks in list");

            List<ItemDTO> itemDTO = result.Select(q => new ItemDTO
            {
                Id = q.Id,
                PriorityId = q.PriorityId,
                Title = q.Title,
                Description = q.Description,
                StatusId = q.StatusId,
            }).ToList();

            return Ok(itemDTO);
        }

        [Route("getbytitle")]
        [HttpGet]
        public IHttpActionResult GetByTitle()
        {
            var result = _itemService.GetByTitle();

            if (result == null) return BadRequest("No tasks in list");

            List<ItemDTO> itemDTO = result.Select(q => new ItemDTO
            {
                Id = q.Id,
                PriorityId = q.PriorityId,
                Title = q.Title,
                Description = q.Description,
                StatusId = q.StatusId,
            }).ToList();

            return Ok(itemDTO);
        }

        [Route("archive/{id:int}")]
        [HttpDelete]
        public IHttpActionResult ArchiveTask([FromUri] int id)
        {
            if (id <= 0) return BadRequest("Request is invalid");

            var result = _itemService.Delete(id);

            if (!result) return BadRequest("Unable to archive task");

            return Ok("Task archived");
        }


    }
}
