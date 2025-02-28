using System;
using System.Data;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using MagicstoreAPI.Infrastructures.DTO;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Repositories;
using MagicstoreAPI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace MagicStoreAPIUnitTest.ServicesTest
{
    public class UsersServiceTest
    {

        private UserService _userService;
        public ServiceCollection serviceCollection;
        public List<Users> _mockUserList;
        public Users _mockUser;
        public UsersDTO _mockUserDTO;
        public Mock<IAuthenticationService1> _mockauthenticationService;
        public Mock<ILogger<UserService>> _mockUsersLogger;
        public Mock<IUserRepository> _mockUsersRepository;
        public string _mockEexceptionMessage;
        public DateTime _mockDate;


        public UsersServiceTest()
        {
            _mockUsersRepository = new Mock<IUserRepository>();
            _mockUsersLogger = new Mock<ILogger<UserService>>();
            _mockUserList = new List<Users>();
            _mockauthenticationService = new Mock<IAuthenticationService1>();
            _mockEexceptionMessage = "Database error";
            _mockDate = DateTime.Now;
            serviceCollection = new ServiceCollection();
            _userService = new UserService(_mockUsersLogger.Object, _mockUsersRepository.Object);


            string password = "MySecurePassword";

            // 1. Generar una sal aleatoria de 16 bytes
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // 2. Crear el hash usando HMACSHA256 con la sal
            byte[] hash;
            using (var hmac = new HMACSHA256(salt))
            {
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }


            _mockUser = new Users()
            {
                ID = 1,
                UserName = "Dollar",
                PasswordHash = hash,
                PasswordSalt = salt,
                Mail = "mailpopo@mail.com",
                CreationDate = _mockDate
            };

            _mockUserDTO = new UsersDTO()
            {
                ID = 1,
                UserName = "Dollar",
                Password = "Password",
                Mail = "mailpopo@mail.com",
                CreationDate = _mockDate
            };

            _mockUserList.Add(new Users()
            {
                ID = 1,
                UserName = "Dollar",
                PasswordHash = hash,
                PasswordSalt = salt,
                Mail = "mailpopo@mail.com",
                CreationDate = _mockDate
            });
            _mockUserList.Add(new Users()
            {
                ID = 2,
                UserName = "Dollar",
                PasswordHash = hash,
                PasswordSalt = salt,
                Mail = "mailpopo@mail.com",
                CreationDate = _mockDate
            });

        }

        [Fact]
        public async void UserService_GetUsers_Is_Succcesful()
        {
            //arrange
            _mockUsersRepository.Setup(x => x.GetUsersRepo()).Returns(Task.FromResult(_mockUserList));
            //act
            var testResult = await _userService.GetUsers();
            //assert
            Assert.Equal(testResult, _mockUserList);
            Assert.InRange(_mockUserList.Count, 1, 2);
        }
        [Fact]
        public async void UserService_GetSingleUser_Is_Succcesful()
        {
            //arrange
            _mockUsersRepository.Setup(x => x.GetUserValue(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(_mockUser));
            //act
            var testResult = await _userService.GetSingleUser(2, "dollar");
            //assert
            Assert.Equal(testResult, _mockUser);
        }
        [Fact]
        public async void UserService_GetSingleUser_ThrowsError()
        {
            //arrange
            _mockUsersRepository.Setup(x => x.GetUserValue(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(_mockUser = null));
            //act
            var testResult = await _userService.GetSingleUser(2, "dollar");
            //assert
            Assert.Null(testResult);
        }
        [Fact]
        public async void UserService_CreateNewUserService_Success()
        {
            //aarange
            _mockUsersRepository.Setup(x => x.CreateNewUser(It.IsAny<UsersDTO>())).Returns(Task.FromResult(_mockUser));
            //act
            var testResult = await _userService.CreateNewUserService(_mockUserDTO);
            //assert
            Assert.True(testResult);
        }
        [Fact]
        public async void UserService_CreateNewUserService_ThrowsEx()
        {
            //aarange
            _mockUsersRepository.Setup(x => x.CreateNewUser(It.IsAny<UsersDTO>())).ThrowsAsync(new Exception(_mockEexceptionMessage));
            //act
            var testResult = await Assert.ThrowsAnyAsync<Exception>(() => _userService.CreateNewUserService(_mockUserDTO));
            //assert
            Assert.Equal(_mockEexceptionMessage, testResult.Message);
        }

        [Fact]
        public async void UserService_UpdateUserService_Success()
        {
            //aarange
            _mockUsersRepository.Setup(x => x.UpdateUser(It.IsAny<UsersDTO>()))
                .ReturnsAsync(_mockUser);
            //act
            var result = await _userService.UpdateUserService(_mockUserDTO);
            //assert
            Assert.True(result);
        }
        [Fact]
        public async void UserService_UpdateUserService_ThrowsException()
        {
            //aarange
            _mockUsersRepository.Setup(x => x.UpdateUser(It.IsAny<UsersDTO>()))
                .ThrowsAsync(new Exception(_mockEexceptionMessage));
            //act
            var testResult = await Assert.ThrowsAnyAsync<Exception>(() => _userService.UpdateUserService(_mockUserDTO));
            //assert
            Assert.Equal(_mockEexceptionMessage, testResult.Message);
        }

        [Fact]
        public async void UserService_DeleteUserService_Succes()
        {
            //Arrange
            _mockUsersRepository.Setup(x => x.DeleteUser(It.IsAny<int>()))
            .ReturnsAsync(_mockUser);
            //Act
            var result = await _userService.DeleteUserService(_mockUser.ID);
            //Assert
            Assert.True(result);
        }
    }
}

