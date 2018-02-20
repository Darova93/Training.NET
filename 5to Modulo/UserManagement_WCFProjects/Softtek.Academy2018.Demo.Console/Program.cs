using Softtek.Academy2018.Demo.Console.ProjectManagementService_Ref;
using Softtek.Academy2018.Demo.Console.UserManagementService_Ref;
using System.ServiceModel;

namespace Softtek.Academy2018.Demo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManagementServiceClient clientUser = null;
            ProjectManagementServiceClient clientProject = null;

            try
            {
                clientUser = new UserManagementServiceClient("BasicHttpBinding_IUserManagementService");
                clientProject = new ProjectManagementServiceClient("BasicHttpBinding_IProjectManagementService");

                UserWorkflow workflow = new UserWorkflow(clientUser);
                ProjectWorkflow projectWorkflow = new ProjectWorkflow(clientProject);

                bool exit = false;

                do
                {
                    System.Console.Clear();
                    System.Console.WriteLine("[1] Create user");
                    System.Console.WriteLine("[2] Read user");
                    System.Console.WriteLine("[3] Update user");
                    System.Console.WriteLine("[4] Delete user");
                    System.Console.WriteLine("[5] Create project");
                    System.Console.WriteLine("[6] Get All projects");
                    System.Console.WriteLine("[0] Exit");
                    System.Console.Write("What do you want to do?:");

                    string opt = System.Console.ReadLine();

                    switch (opt)
                    {
                        case "0":
                            exit = true;
                            break;
                        case "1":
                            //client.Open();
                            workflow.CreateUser();
                            //client.Close();
                            break;
                        case "2":
                            //client.Open();
                            workflow.ReadUser();
                            //client.Close();
                            break;
                        case "3":
                            //client.Open();
                            workflow.UpdateUser();
                            //client.Close();
                            break;
                        case "4":
                            //client.Open();
                            workflow.Delete();
                            //client.Close();
                            break;
                        case "5":
                            projectWorkflow.Create();
                            break;
                        case "6":
                            projectWorkflow.GetAll();
                            break;
                    }

                    System.Console.Write("Continue...");
                    System.Console.ReadKey();

                } while (!exit);
            }
            finally
            {
                if (clientUser != null && clientUser.State == CommunicationState.Opened)
                {
                    clientUser.Close();
                }

                if (clientProject != null && clientProject.State == CommunicationState.Opened)
                {
                    clientProject.Close();
                }

            }


        }
    }
}
