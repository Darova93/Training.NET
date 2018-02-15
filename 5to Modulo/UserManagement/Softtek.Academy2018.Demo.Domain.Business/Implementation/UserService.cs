using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Domain.Model;
using System;

namespace Softtek.Academy2018.Demo.Business.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int Add(User user)
        {
            bool isExist = _userRepository.Exist(user.IS);
            if (isExist) return 0;

            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName)) return 0;

            if (!user.DateOfBirth.HasValue) return 0;

            bool validAge = DateTime.Now.Year - user.DateOfBirth.Value.Year < 18;
            if (validAge) return 0;

            int id = _userRepository.Add(user);

            return 1;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
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
