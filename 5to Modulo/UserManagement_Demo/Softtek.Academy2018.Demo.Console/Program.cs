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
            bool exit = false;

            UserWorkflow workflow = new UserWorkflow();

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

    public class UserWorkflow
    {
        private IUserRepository _repository;
        private IUserService _service;

        public UserWorkflow()
        {
            _repository = new UserFakeRepository();
            _service = new UserService(_repository);
        }

        public void CreateUser()
        {
            System.Console.WriteLine("---Create new user---");

            System.Console.Write("IS:");
            string IS = System.Console.ReadLine();
            System.Console.Write("First Name:");
            string firstName = System.Console.ReadLine();
            System.Console.Write("Last Name:");
            string lastName = System.Console.ReadLine();
            System.Console.Write("Date of Birth (MM/DD/YYYY):");
            DateTime dateOfBirth = DateTime.Parse(System.Console.ReadLine());
            System.Console.Write("Salary:");
            double salary = double.Parse(System.Console.ReadLine());

            User user = new User
            {
                IS = IS,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Salary = salary
            };

            int id = _service.Add(user);

            if (id <= 0)
            {
                System.Console.WriteLine("Error: Unable to create user");
            }
            else
            {
                System.Console.WriteLine($"Success: User created, Id: {id}");
            }

            System.Console.WriteLine("------------------");
        }

        public void ReadUser()
        {
            System.Console.WriteLine("---View user---");

            System.Console.Write("Id:");
            int id = int.Parse(System.Console.ReadLine());

            User user = _service.Get(id);

            if (user == null)
            {
                System.Console.WriteLine("Error: User not found");
            }
            else
            {
                System.Console.WriteLine("Success: User found");
                System.Console.WriteLine($"IS:{user.IS}");
                System.Console.WriteLine($"First Name:{user.FirstName}");
                System.Console.WriteLine($"Last Name:{user.LastName}");
                System.Console.WriteLine($"Date of Birth:{user.DateOfBirth.Value.ToString("MM/dd/yyyy")}");
                System.Console.WriteLine($"Salary:{user.Salary}");
                System.Console.WriteLine($"Created date:{user.CreatedDate}");
                System.Console.WriteLine($"Modified date:{(user.ModifiedDate.HasValue ? user.ModifiedDate.Value.ToString() : string.Empty)}");
            }

            System.Console.WriteLine("------------------");
        }

        public void UpdateUser()
        {
            System.Console.WriteLine("---Update user---");

            System.Console.Write("Id:");
            int id = int.Parse(System.Console.ReadLine());

            User user = _service.Get(id);

            if (user == null)
            {
                System.Console.WriteLine("Error: User not found");
                return;
            }

            System.Console.WriteLine("Success: User found");
            System.Console.WriteLine($"IS:{user.IS}");
            System.Console.WriteLine("Press [ESC] to skip");
            if (System.Console.ReadKey(true).Key != System.ConsoleKey.Escape)
            {
                System.Console.Write("New IS:");
                user.IS = System.Console.ReadLine();
            }

            System.Console.WriteLine($"First Name:{user.FirstName}");
            System.Console.WriteLine("Press [ESC] to skip");
            if (System.Console.ReadKey(true).Key != System.ConsoleKey.Escape)
            {
                System.Console.Write("New First Name:");
                user.FirstName = System.Console.ReadLine();
            }

            System.Console.WriteLine($"Last Name:{user.LastName}");
            System.Console.WriteLine("Press [ESC] to skip");
            if (System.Console.ReadKey(true).Key != System.ConsoleKey.Escape)
            {
                System.Console.Write("New Last Name:");
                user.LastName = System.Console.ReadLine();
            }

            System.Console.WriteLine($"Date of Birth:{user.DateOfBirth.Value.ToString("MM/dd/yyyy")}");
            System.Console.WriteLine("Press [ESC] to skip");
            if (System.Console.ReadKey(true).Key != System.ConsoleKey.Escape)
            {
                System.Console.Write("New Date of Birth:");
                user.DateOfBirth = DateTime.Parse(System.Console.ReadLine());
            }

            System.Console.WriteLine($"Salary:{user.Salary}");
            System.Console.WriteLine("Press [ESC] to skip");
            if (System.Console.ReadKey(true).Key != System.ConsoleKey.Escape)
            {
                System.Console.Write("New Salary:");
                user.Salary = double.Parse(System.Console.ReadLine());
            }

            bool result = _service.Update(user);

            if (!result)
            {
                System.Console.WriteLine("Error: Unable to update user");
            }
            else
            {
                System.Console.WriteLine($"Success: User updated");
            }

            System.Console.WriteLine("------------------");
        }

        public void Delete()
        {
            System.Console.WriteLine("---Delete user---");

            System.Console.Write("Id:");
            int id = int.Parse(System.Console.ReadLine());

            User user = _service.Get(id);

            if (user == null)
            {
                System.Console.WriteLine("Error: User not found");
                return;
            }

            System.Console.WriteLine("Success: User found");

            System.Console.WriteLine("Do you want to delete the user?[Y/n]");

            if (System.Console.ReadKey(true).Key == System.ConsoleKey.Y)
            {
                bool result = _service.Delete(id);

                if (!result)
                {
                    System.Console.WriteLine("Error: Unable to delete user");
                }
                else
                {
                    System.Console.WriteLine($"Success: User deleted");
                }
            }

            System.Console.WriteLine("------------------");
        }
    }

}
