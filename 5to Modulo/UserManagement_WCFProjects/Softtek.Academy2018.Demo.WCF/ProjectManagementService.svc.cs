using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Softtek.Academy2018.Demo.WCF.Messages;
using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Data.Implementation;
using Softtek.Academy2018.Demo.Business.Implementation;
using Softtek.Academy2018.Demo.Domain.Model;
using Softtek.Academy2018.Demo.WCF.DTO;

namespace Softtek.Academy2018.Demo.WCF
{
    public class ProjectManagementService : IProjectManagementService
    {
        private readonly IProjectService _service;

        public ProjectManagementService()
        {
            IProjectRepository repository = new ProjectDataRepository();
            _service = new ProjectService(repository);
        }

        public CreateProjectResponse CreateProject(CreateProjectRequest request)
        {
            if (request == null)
            {
                return new CreateProjectResponse
                {
                    Success = false,
                    Message = "Error: null request"
                };
            }

            Project project = new Project
            {
                Name = request.Name,
                Area = request.Area,
                TechnologyStack = request.TechnologyStack
            };

            int id = _service.Add(project);

            if (id == 0)
            {
                return new CreateProjectResponse
                {
                    Success = false,
                    Message = "Error: unable to create project"
                };
            }

            return new CreateProjectResponse
            {
                Success = true,
                ProjectId = id
            };

        }

        public GetProjectResponse GetProject(GetProjectRequest request)
        {
            if (request == null)
                return new GetProjectResponse
                {
                    Success = false,
                    Message = "Error: null request"
                };

            var projects = _service.GetAll().ToList();

            if (projects == null)
                return new GetProjectResponse
                {
                    Success = false,
                    Message = "Error: There are no projects"
                };

            //var projectsDTO = new List<ProjectDTO>();

            //foreach (var item in projects)
            //{
            //    projectsDTO.Add(new ProjectDTO
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        Area = item.Area,
            //        TechnologyStack = item.TechnologyStack
            //    });
            //}

            ICollection<ProjectDTO> projectList = projects.Select(p => new ProjectDTO
            {
                Id = p.Id,
                Name = p.Name,
                Area = p.Area,
                TechnologyStack = p.TechnologyStack
            }).ToList();


            return new GetProjectResponse
            {
                Success = true,
                Projects = projectList
            };
        }
    }
}
