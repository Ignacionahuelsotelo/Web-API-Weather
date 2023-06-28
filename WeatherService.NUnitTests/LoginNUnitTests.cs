using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Controllers.Dtos;
using WeatherApi.Interactors;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.NUnitTests
{
    [TestFixture]
    public class LoginNUnitTests
    {
        string email;
        string password;
        string name;
        int id;

        [SetUp]
        public void Setup()
        {
            email = "test@gmail.com";
            password = "912";
            name = "prueba";
            id = 10;

        }

        [Test]
        public async Task GetUserWithCorrectEmailAndPassword ()
        {

            Mock<IUserService> mockUserService = new Mock<IUserService> ();
            mockUserService.Setup(s =>  s.GetUser(email, password)).ReturnsAsync(new User() { Email = email, Password = password , Id = id, Name = name});

            User userExpected = new User();
            userExpected.Email = email;
            userExpected.Password = password;
            userExpected.Name = name;
            userExpected.Id = id;

            User user = await mockUserService.Object.GetUser(email, password);

            Assert.AreEqual(userExpected,user);

        }

        [Test]
        public async Task GetNullWithIncorrectEmailAndCorrectPassword()
        {
            Mock<IUserService> mockUserService = new Mock<IUserService>();
            mockUserService.Setup(s => s.GetUser(email, password)).ReturnsAsync(new User() { Email = email, Password = password, Id = id, Name = name });

            User user = await mockUserService.Object.GetUser("incorrect email", password);

            Assert.IsNull(user);
            
        }

        [Test]
        public async Task GetNullWithIncorrectPasswordAndCorrectEmail()
        {
            Mock<IUserService> mockUserService = new Mock<IUserService>();
            mockUserService.Setup(s => s.GetUser(email, password)).ReturnsAsync(new User() { Email = email, Password = password, Id = id, Name = name });

            User user = await mockUserService.Object.GetUser(email, "incorrect password");

            Assert.IsNull(user);

        }


    }
}
