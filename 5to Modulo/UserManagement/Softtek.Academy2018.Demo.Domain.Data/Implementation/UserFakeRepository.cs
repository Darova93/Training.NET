
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.Demo.Domain.Model;
using Softtek.Academy2018.Demo.Data.Contracts;

namespace Softtek.Academy2018.Demo.Data.Implementation
{
    public class UserFakeRepository : IUserRepository
    { 
        private static List<User> _users = new List<User>();

        public int Add(User user)
        {
            int id = _users.Count + 1;
            user.Id = id;
            _users.Add(user);
            return id;
        }

        public bool Delete(int id)
        {
            _users.Remove(_users.Find(x=>x.Id == id));
            return true;
        }

        public int ISExist(string @is, int id)
        {
            User found = _users.FirstOrDefault(x => x.IS.ToLower() == @is.ToLower());
            if ((found != null) && (found.Id != id))
            {
                return 1;
            }
            else if ((found != null) && (found.Id == id))
            {
                return 2;
            }
            return 0;
        }
            
        public User Get(int id)
        {
            return _users.Find(x => x.Id == id);
        }

        public bool isActive(int id)
        {
            return _users.SingleOrDefault(x => x.Id == id).IsActive;
        }

        public bool Update(User user)
        {
            User olduser = new User();
            olduser = _users.SingleOrDefault(i => i.Id == user.Id);
            olduser = user;
            return true;
        }

        public bool userExists(int id)
        {
            if (_users.SingleOrDefault(x => x.Id == id) != null)
            {
                return true;
            }
            else return false;
        }
    }
}
