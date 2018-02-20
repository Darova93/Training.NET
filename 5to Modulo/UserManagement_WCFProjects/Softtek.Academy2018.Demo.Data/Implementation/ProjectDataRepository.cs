using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Data.Implementation
{
    public class ProjectDataRepository : IProjectRepository
    {
        public int Add(Project project)
        {
            using (var context= new UserManagementContext())
            {
                context.Projects.Add(project);
                context.SaveChanges();
                return project.Id;
            }
        }

        public ICollection<Project> GetAll()
        {
            using (var context= new UserManagementContext())
            {
                return context.Projects.ToList();
            }
        }

        public bool Exist(string name)
        {
            using (var context = new UserManagementContext())
            {
               return context.Projects.Any(e => e.Name.ToLower() == name.ToLower());
            }
        }
    }
}
