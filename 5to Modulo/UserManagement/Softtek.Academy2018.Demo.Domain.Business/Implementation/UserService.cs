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
            int isExist = _userRepository.ISExist(user.IS, user.Id);
            if (isExist == 1 || isExist == 2) return 0;

            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName)) return 0;

            if (!user.DateOfBirth.HasValue) return 0;

            bool validAge = DateTime.Now.Year - user.DateOfBirth.Value.Year < 18;
            if (validAge) return 0;

            int id = _userRepository.Add(user);

            return 1;
        }

        public bool Delete(int id)
        {
            bool userExists = _userRepository.userExists(id);
            bool isActive = _userRepository.isActive(id);

            if ((userExists) && (isActive)) return _userRepository.Delete(id);

            return false;
        }

        public User Get(int id)
        {
            bool userExists = _userRepository.userExists(id);
            bool isActive = _userRepository.isActive(id);

            if ((userExists) && (isActive)) return _userRepository.Get(id);

            return null;
        }

        public bool Update(User user)
        {
            bool userExists = _userRepository.userExists(user.Id);
            if (!userExists) return false;

            int isExist = _userRepository.ISExist(user.IS, user.Id);
            if (isExist == 1) return false;

            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName)) return false;

            if (!user.DateOfBirth.HasValue) return false;

            bool validAge = DateTime.Now.Year - user.DateOfBirth.Value.Year < 18;
            if (validAge) return false;

            bool result = _userRepository.Update(user);

            return true;
        }
    }
}
