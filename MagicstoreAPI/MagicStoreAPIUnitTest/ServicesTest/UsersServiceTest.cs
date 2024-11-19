    using System;
    using System.Data;
    using System.Security;
    using MagicstoreAPI.Infrastructures.Entities;
    using MagicstoreAPI.Interfaces;
    using MagicstoreAPI.Services;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Moq;

namespace MagicStoreAPIUnitTest.ServicesTest
{
    public class UsersServiceTest
    {

        public Mock<IUserRepository> _mockUsersRepository;
        public Mock<ILogger<UserService>> _mockUsersLogger;
        public ServiceCollection serviceCollection;
        public IUserService _iUsersService;
        public List<Users> _mockUserList;
        public Users _mockUser;
        public string _mockEexceptionMessage;
        public DateTime _mockDate;


        public UsersServiceTest()
        {
            _mockUsersRepository = new Mock<IUserRepository>();
            _mockUsersLogger = new Mock<ILogger<UserService>>();
            _mockUserList = new List<Users>();
            _mockEexceptionMessage = "Database error";
            _mockDate = DateTime.Now;
            serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IUserService, UserService>(x =>
            {
                return new UserService(_mockUsersLogger.Object,
                    _mockUsersRepository.Object);
            });
            _iUsersService = serviceCollection.BuildServiceProvider().GetRequiredService<IUserService>();

            _mockUser = new Users()
            {
                ID = 1,
                UserName = "Dollar",
                Password = "POPO",
                RoleID = 2,
                Mail = "mailpopo@mail.com",
                CreationDate = _mockDate
            };

            _mockUserList.Add(new Users()
            {
                ID = 1,
                UserName = "Dollar",
                Password = "POPO",
                RoleID = 2,
                Mail = "mailpopo@mail.com",
                CreationDate = _mockDate
            });
            _mockUserList.Add(new Users()
            {
                ID = 2,
                UserName = "Dollar",
                Password = "POPO",
                RoleID = 2,
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
            var testResult = await _iUsersService.GetUsers();
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
            var testResult = await _iUsersService.GetSingleUser(2,"dollar");
            //assert
            Assert.Equal(testResult, _mockUser);
        }
        [Fact]
        public async void UserService_GetSingleUser_ThrowsError()
        {
            //arrange
            _mockUsersRepository.Setup(x => x.GetUserValue(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(_mockUser=null));
            //act
            var testResult = await _iUsersService.GetSingleUser(2, "dollar");
            //assert
            Assert.Null(testResult);
        }
        [Fact]
        public async void UserService_CreateNewUserService_Success()
        {
            //aarange
            _mockUsersRepository.Setup(x => x.CreateNewUser(It.IsAny<Users>())).Returns(Task.FromResult(_mockUser));
            //act
            var testResult = await _iUsersService.CreateNewUserService(_mockUser);
            //assert
            Assert.True(testResult);
        }
        [Fact]
        public async void UserService_CreateNewUserService_ThrowsEx()
        {
            //aarange
            _mockUsersRepository.Setup(x => x.CreateNewUser(It.IsAny<Users>())).ThrowsAsync(new Exception(_mockEexceptionMessage));
            //act
            var testResult = await Assert.ThrowsAnyAsync<Exception>(() => _iUsersService.CreateNewUserService(_mockUser));
            //assert
            Assert.Equal(_mockEexceptionMessage , testResult.Message);
        }

        [Fact]
        public async void UserService_UpdateUserService_Success()
        {
            //aarange
            _mockUsersRepository.Setup(x => x.UpdateUser(It.IsAny<Users>()))
                .ReturnsAsync(_mockUser);
            //act
            var result = await _iUsersService.UpdateUserService(_mockUser);
            //assert
            Assert.True(result);
        }
        [Fact]
        public async void UserService_UpdateUserService_ThrowsException()
        {
            //aarange
            _mockUsersRepository.Setup(x => x.UpdateUser(It.IsAny<Users>()))
                .ThrowsAsync(new Exception(_mockEexceptionMessage));
            //act
            var testResult = await Assert.ThrowsAnyAsync<Exception>(() => _iUsersService.UpdateUserService(_mockUser));
            //assert
            Assert.Equal(_mockEexceptionMessage,testResult.Message);
        }

        [Fact]
        public async void UserService_DeleteUserService_Succes()
        {
            //Arrange
            _mockUsersRepository.Setup(x => x.DeleteUser(It.IsAny<int>()))
            .ReturnsAsync(_mockUser);
            //Act
            var result = await _iUsersService.DeleteUserService(_mockUser.ID);
            //Assert
            Assert.True(result);
        }
    }
}

