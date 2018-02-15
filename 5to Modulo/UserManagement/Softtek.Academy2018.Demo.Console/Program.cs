using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Business.Implementation;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Data.Implementation;
using Softtek.Academy2018.Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User
            {
                IS = "JAMU",
                FirstName = "Juan",
                LastName = "Ramos",
                DateOfBirth = new DateTime(1984, 12, 12)
            };
            IUserRepository repository = new UserFakeRepository();
            IUserService service = new UserService(repository);

            int id = service.Add(user);

            if (id == 0)
            {
                System.Console.WriteLine("Invalid User!!!");
            }

            //Create new user
            System.Console.WriteLine($"New user id {id}");
            System.Console.ReadKey();
        }
    }
}
