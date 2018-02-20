using Softtek.Academy2018.Demo.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.Demo.Domain.Model;

namespace Softtek.Academy2018.Demo.Data.Implementation
{
    public class ProjectFakeRepository : IProjectRepository
    {
        private static List<Project> _projects = new List<Project>();

        public int Add(Project project)
        {
            int id = _projects.Count + 1;

            _projects.Add(project);

            return id;
        }

        public bool AssignUser(int projectid, int userid)
        {
            Project project = _projects.SingleOrDefault(p => p.Id == projectid);
            return false;
        }

        public bool Exists(string name)
        {
            return _projects.Any(n => n.Name.ToLower() == name.ToLower());
        }

        public ICollection<Project> GetAll()
        {
            return _projects;
        }

        public bool UserAlreadyOnProject(int projectid, int userid)
        {
            throw new NotImplementedException();
        }
    }
}
