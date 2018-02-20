using Softtek.Academy2018.Demo.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.Demo.Domain.Model;
using Softtek.Academy2018.Demo.Data.Contracts;

namespace Softtek.Academy2018.Demo.Business.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public int Add(Project project)
        {
            if (project.Id != 0) return 0;

            if ((string.IsNullOrEmpty(project.Name)) || (string.IsNullOrEmpty(project.Area)) || (string.IsNullOrEmpty(project.TechnologyStack))) return 0;

            if (project.Contributors.Count != 0) return 0;

            bool projectexists = _projectRepository.Exists(project.Name);
            if (projectexists == true) return 0;

            int id = _projectRepository.Add(project);
            return id;
        }

        public bool AssignUser(int projectid, int userid)
        {
            if (projectid <= 0) return false;
            if (userid <= 0) return false;
            if (_projectRepository.UserAlreadyOnProject(projectid, userid) == true) return false;

            return _projectRepository.AssignUser(projectid, userid);
        }

        public ICollection<Project> GetAll()
        {
            return _projectRepository.GetAll();
        }
    }
}
