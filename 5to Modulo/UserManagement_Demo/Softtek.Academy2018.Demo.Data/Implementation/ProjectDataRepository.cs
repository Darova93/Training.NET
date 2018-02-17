using Softtek.Academy2018.Demo.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.Demo.Domain.Model;

namespace Softtek.Academy2018.Demo.Data.Implementation
{
    public class ProjectDataRepository : IProjectRepository
    {
        public int Add(Project project)
        {
            using (var context = new DBContext())
            {
                if (project == null) return 0;

                context.Projects.Add(project);
                context.SaveChanges();

                return project.Id;
            }
        }

        public bool AssignUser(int projectid, int userid)
        {
            using (var context = new DBContext())
            {
                Project project = context.Projects.SingleOrDefault(p => p.Id == projectid);
                User user = context.Users.SingleOrDefault(u => u.Id == userid);

                if ((project == null) || (user == null)) return false;

                project.Contributors.Add(user);
                
                context.SaveChanges();

                return true;
            }
        }

        public bool Exists(string name)
        {
            using (var context = new DBContext())
            {
                return context.Projects.Any(x => x.Name.ToLower() == name.ToLower());
            }
        }

        public ICollection<Project> GetAll()
        {
            using (var context = new DBContext())
            {
                 
                return context.Projects.ToList();

            }
        }

        public bool UserAlreadyOnProject(int projectid, int userid)
        {
            using (var context = new DBContext())
            {
                Project project = context.Projects.SingleOrDefault(p => p.Id == projectid);
                if(project != null)
                {
                    return project.Contributors.Any(u => u.Id == userid);
                }
                return false;
            }
        }
    }
}
