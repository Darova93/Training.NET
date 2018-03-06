﻿using Ninject;
using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Business.Implementation;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Data.Implementation;
using Softtek.Academy2018.Demo.Domain.Model;
using System;

namespace Softtek.Academy2018.Demo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = FactoryDependency.GetKernel();

            IUserService userservice = kernel.Get<IUserService>();
            IProjectService projectservice = kernel.Get<IProjectService>();

            //Create workflow instance
            UserWorkflow userworkflow = new UserWorkflow(userservice);
            ProjectWorkFlow projectworkflow = new ProjectWorkFlow(projectservice);

            bool exit = false;

            do
            {
                System.Console.Clear();
                System.Console.WriteLine("[1] Create user");
                System.Console.WriteLine("[2] Read user");
                System.Console.WriteLine("[3] Update user");
                System.Console.WriteLine("[4] Delete user");
                System.Console.WriteLine("[5] Create project");
                System.Console.WriteLine("[6] Read projects");
                System.Console.WriteLine("[7] Assign user to project");
                System.Console.WriteLine("[0] Exit");
                System.Console.Write("What do you want to do?:");

                string opt = System.Console.ReadLine();

                switch (opt)
                {
                    case "0":
                        exit = true;
                        break;
                    case "1":
                        userworkflow.CreateUser();
                        break;
                    case "2":
                        userworkflow.ReadUser();
                        break;
                    case "3":
                        userworkflow.UpdateUser();
                        break;
                    case "4":
                        userworkflow.Delete();
                        break;
                    case "5":
                        projectworkflow.CreateProject();
                        break;
                    case "6":
                        projectworkflow.GetAll();
                        break;
                    case "7":
                        projectworkflow.AssignUser();
                        break;
                }

                System.Console.Write("Continue...");
                System.Console.ReadKey();

            } while (!exit);

        }
    }

}