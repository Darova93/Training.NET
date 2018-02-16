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
            User user0 = new User
            {
                IS = "JAMU",
                FirstName = "Juan",
                LastName = "Ramos",
                DateOfBirth = new DateTime(1984, 12, 12)
            };

            User user1 = new User
            {
                IS = "DRVA",
                FirstName = "David",
                LastName = "Rodriguez",
                DateOfBirth = new DateTime(1984, 12, 12)
            };

            User user2 = new User
            {
                IS = "DRAM",
                FirstName = "David",
                LastName = "Ramos",
                DateOfBirth = new DateTime(1984, 12, 12)
            };

            IUserRepository repository = new UserFakeRepository();
            IUserService service = new UserService(repository);

            int id = service.Add(user0);
            int id1 = service.Add(user1);
            int id2 = service.Add(user2);
            int id3 = service.Add(user1);

            if (id == 0)
            {
                System.Console.WriteLine("Invalid User!!!");
            }

            bool resultu = service.Update(new User {    
                Id = 1,
                IS = "DRVA",
                FirstName = "Juan",
                LastName = "Ramos",
                DateOfBirth = new DateTime(1984, 12, 12)
            });

            bool resultu1 = service.Update(new User
            {
                Id=1,
                IS = "JRAM",
                FirstName = "Juan",
                LastName = "Ramos",
                DateOfBirth = new DateTime(1984, 12, 12)
            });

            //Create new user
            
            System.Console.WriteLine($"New user id {id}, {id1}, {id2}, {id3}");
            System.Console.WriteLine($"Update results {resultu}, {resultu1}");
            System.Console.ReadKey();
        }
    }
}
