using Softtek.Academy2018.Demo.Console.ProjectManagementService_Ref;
using Softtek.Academy2018.Demo.Console.UserManagementService_Ref;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Console
{
    public class ProjectWorkflow
    {
        private readonly ProjectManagementServiceClient _projectClient;

        public ProjectWorkflow(ProjectManagementServiceClient projectClient)
        {
            _projectClient = projectClient;
        }

        public void Create()
        {
            System.Console.WriteLine("---Create new Project---");

            System.Console.Write("Name:");
            string Name = System.Console.ReadLine();
            System.Console.Write("Area:");
            string Area = System.Console.ReadLine();
            System.Console.Write("TechnologyStack");
            string TechnologyStack = System.Console.ReadLine();

            CreateProjectRequest request = new CreateProjectRequest
            {
                Name = Name,
                Area = Area,
                TechnologyStack = TechnologyStack
            };

            CreateProjectResponse response = _projectClient.CreateProject(request);

            if (response.Success == false)
            {
                System.Console.WriteLine("Error: Unable to create the project");
            }
            else
            {
                System.Console.WriteLine($"Success: project created, Id: {response.ProjectId}");
            }

            System.Console.WriteLine("------------------");
        }

        public void GetAll()
        {
            System.Console.WriteLine("Get all the projects...");

            GetProjectRequest request = new GetProjectRequest { };
            GetProjectResponse response = _projectClient.GetProject(request);
            var projectlist = response.Projects;
            foreach (var p in projectlist)
            {
                System.Console.WriteLine($"Id {p.Id}\n" +
                    $"Area {p.Area}\n" +
                    $"Name {p.Name}\n" +
                    $"Technology Stack {p.TechnologyStack}");
                System.Console.WriteLine("-------------");
            }
            System.Console.WriteLine("-------------");
            System.Console.WriteLine("-------------");
        }
    }
}
