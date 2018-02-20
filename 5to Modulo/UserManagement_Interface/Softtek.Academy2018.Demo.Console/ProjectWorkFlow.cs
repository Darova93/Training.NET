using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Console
{
    public class ProjectWorkFlow
    {
        private IProjectService _projectService;

        public ProjectWorkFlow(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public void CreateProject()
        {
            System.Console.WriteLine("---Create new project---");

            System.Console.Write("Project Name:");
            string projectName = System.Console.ReadLine();
            System.Console.Write("Area:");
            string area = System.Console.ReadLine();
            System.Console.Write("Technology Stack:");
            string technologyStack = System.Console.ReadLine();

            Project project = new Project
            {
                Name = projectName,
                Area = area,
                TechnologyStack = technologyStack
            };

            int id = _projectService.Add(project);

            if (id <= 0)
            {
                System.Console.WriteLine("Error: Unable to create project");
            }
            else
            {
                System.Console.WriteLine($"Success: Project created, Id: {id}");
            }

            System.Console.WriteLine("------------------");
        }

        public void GetAll()
        {
            System.Console.WriteLine("---View projects---");

            ICollection<Project> project = _projectService.GetAll();

            if (project == null)
            {
                System.Console.WriteLine("Error: No projects found");
            }
            else
            {
                foreach (var item in project)
                {
                    System.Console.WriteLine($"Project #{item.Id}");
                    System.Console.WriteLine($"Name:{item.Name}");
                    System.Console.WriteLine($"Area:{item.Area}");
                    System.Console.WriteLine($"TechnologyStack:{item.TechnologyStack}");
                    System.Console.WriteLine("------------------");
                }
            }

            System.Console.WriteLine("------------------");
        }

        public void AssignUser()
        {
            System.Console.WriteLine("---Assign user to project---");

            System.Console.WriteLine("Project Id: ");
            int projectid = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("User Id: ");
            int userid = int.Parse(System.Console.ReadLine());

            if ((projectid <= 0) || (userid <= 0))
            {
                System.Console.WriteLine("Error: Invalid user or project");
            }
            else
            {
                bool result = _projectService.AssignUser(projectid, userid);

                if (result == true)
                {
                    System.Console.WriteLine("Succesfully assigned the user to the project");
                }
                else
                {
                    System.Console.WriteLine("User/project doesn't exists or is already assigned to the project");
                }
            }


            System.Console.WriteLine("------------------");
        }
    }
}
