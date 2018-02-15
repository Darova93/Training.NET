using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Business.Implementation;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Domain.Model;
using System;

namespace Sofftek.Academy2018.Demo.Business.Implementation.Test
{
    [TestClass()]
    public class UserServiceTests
    {
        [TestMethod()]
        public void When_add_a_valid_user()
        {
            int expectedId = 1;
            Mock<IUserRepository> repository = new Mock<IUserRepository>();
            repository.Setup(x => x.Exist(It.IsAny<string>())).Returns(true);
            IUserService service = new UserService(repository.Object);

            User user = new User
            {
                IS = "JAMU",
                FirstName = "Juan",
                LastName = "Ramos",
                DateOfBirth = new DateTime(1984, 12, 12)
            };

            int resultId = service.Add(new User());
            Assert.AreEqual(expectedId, resultId);
        }
    }
}