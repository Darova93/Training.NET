using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Data;
using Softtek.Academy2018.Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Data.Implementation
{
    public class UserFakeRepository : IUserRepository
    {
        //private static List<User> _users = new List<User>();

        public int Add(User user)
        {
            //int id = _users.Count + 1;

            //user.Id = id;
            user.CreatedDate = DateTime.Now;
            user.ModifiedDate = null;
            user.IsActive = true;

            using (var context = new DBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
                var lastid = context.Users.OrderByDescending(e => e.Id).First().Id;
                return lastid;
            }
        }

        public bool Delete(int id)
        {

            using (var context = new DBContext())
            {
                User user = context.Users.SingleOrDefault(x => x.Id == id);

                if (user == null) return false;

                context.Users.SingleOrDefault(x => x.Id == id).IsActive = false; 
            }

            return true;
        }

        public bool Exist(string @is)
        {
            using (var context = new DBContext())
            {
                return context.Users.Any(x => x.IS.ToLower() == @is.ToLower()); 
            }
        }

        public User Get(int id)
        {
            using (var context = new DBContext())
            {
                return context.Users.SingleOrDefault(x => x.Id == id && x.IsActive);
            } 
        }

        public string GetIS(int id)
        {
            using (var context = new DBContext())
            {
                return context.Users.SingleOrDefault(x => x.Id == id).IS ?? null; 
            }
        }

        public bool Update(User user)
        {
            using (var context = new DBContext())
            {
                User currentUser = context.Users.SingleOrDefault(x => x.Id == user.Id);

                if (currentUser == null) return false;

                currentUser.IS = user.IS;
                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                currentUser.DateOfBirth = user.DateOfBirth;
                currentUser.Salary = user.Salary;
                currentUser.ModifiedDate = DateTime.Now; 
            }

            return true;
        }
    }
}
