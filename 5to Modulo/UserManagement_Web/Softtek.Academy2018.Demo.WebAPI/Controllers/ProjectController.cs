using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Business.Implementation;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Data.Implementation;
using Softtek.Academy2018.Demo.Domain.Model;
using Softtek.Academy2018.Demo.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Softtek.Academy2018.Demo.WebAPI.Controllers
{
    [RoutePrefix("api/projects")]
    public class ProjectController : ApiController
    {
        private readonly IProjectService _projectService;
        private readonly IProjectUserService _projectUserService;

        public ProjectController(IProjectService service, IProjectUserService projectUserService)
        {
            _projectService = service;
            _projectUserService = projectUserService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] ProjectDTO projectDTO)
        {
            if (projectDTO == null) return BadRequest("Project is null");

            Project project = new Project
            {
                Name = projectDTO.Name,
                Area = projectDTO.Area,
                TechnologyStack = projectDTO.TechnologyStack
            };

            int id = _projectService.Add(project);

            if (id <= 0)
            {
                return BadRequest("Unable to create project");
            }

            var payload = new { ProjectId = id };

            return Ok();
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var projects = _projectService.GetAll();

            if (projects == null) return NotFound();

            List<ProjectDTO> projectsDTO = projects.Select(q => new ProjectDTO
            {
                Id = q.Id,
                Name = q.Name,
                Area = q.Area,
                TechnologyStack = q.TechnologyStack
            }).ToList();

            return Ok(projectsDTO);
        }

        [Route("add/user/{userid:int}/project/{projectid:int}")]
        [HttpPost]
        public IHttpActionResult AssignUserToProject([FromUri] int userid, [FromUri] int projectid)
        {
            if (userid <= 0 || projectid <= 0) return BadRequest("Invalid id(s)");

            var result = _projectUserService.AddUserToProject(projectid, userid);

            if (!result) return BadRequest("Unable to assign user");
            
            return Ok("User assigned to project");
        }

        [Route("remove/user/{userid:int}/project/{projectid:int}")]
        [HttpPost]
        public IHttpActionResult RemoveUserToProject([FromUri] int userid, [FromUri] int projectid)
        {
            if (userid <= 0 || projectid <= 0) return BadRequest("Invalid id(s)");

            var result = _projectUserService.RemoveUserFromProject(projectid, userid);

            if (!result) return BadRequest("Unable to remove user");

            return Ok("User removed from project");
        }
    }
}
