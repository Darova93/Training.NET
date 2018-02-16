using Ninject;
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

            IUserService service = kernel.Get<IUserService>();

            //Create workflow instance
            UserWorkflow workflow = new UserWorkflow(service);

            bool exit = false;

            do
            {
                System.Console.Clear();
                System.Console.WriteLine("[1] Create user");
                System.Console.WriteLine("[2] Read user");
                System.Console.WriteLine("[3] Update user");
                System.Console.WriteLine("[4] Delete user");
                System.Console.WriteLine("[0] Exit");
                System.Console.Write("What do you want to do?:");

                string opt = System.Console.ReadLine();

                switch (opt)
                {
                    case "0":
                        exit = true;
                        break;
                    case "1":
                        workflow.CreateUser();
                        break;
                    case "2":
                        workflow.ReadUser();
                        break;
                    case "3":
                        workflow.UpdateUser();
                        break;
                    case "4":
                        workflow.Delete();
                        break;
                }

                System.Console.Write("Continue...");
                System.Console.ReadKey();

            } while (!exit);

        }
    }

}
