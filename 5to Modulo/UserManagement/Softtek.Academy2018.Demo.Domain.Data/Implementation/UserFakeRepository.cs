
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
            throw new NotImplementedException();
        }

        public bool Exist(string @is)
        {
            return _users.Any(x => x.IS.ToLower() == @is.ToLower());
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
