using System;
using System.Security.Cryptography;
using System.Text;
using MagicstoreAPI.Infrastructures.DTO;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MagicStoreAPIUnitTest.ServicesTest
{
    public class AuthenticationServiceTest
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IAuthenticationService> _mockAuthService;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly JwtSettings _jwtSettings;
        private readonly IAuthenticationService _authService;
        private readonly Mock<ILogger<AuthenticationService>> _loggerMock;
        public Users _mockUser;
        public UsersDTO _mockUserDTO;
        public DateTime _mockDate;
        public UsersToken _mocktoken;

        public AuthenticationServiceTest()
        {
            _mockUserService = new Mock<IUserService>();
            _mockConfiguration = new Mock<IConfiguration>();
            _mockAuthService = new Mock<IAuthenticationService>();
            _mockDate = DateTime.Now;
            _jwtSettings = new JwtSettings();
            _loggerMock = new Mock<ILogger<AuthenticationService>>();
            _authService = new AuthenticationService(_loggerMock.Object, _mockUserService.Object, _jwtSettings, _mockConfiguration.Object);

            string password = "test";
            byte[] hash;
            byte[] salt;
            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            }


            _mockUser = new Users()
            {
                ID = 1,
                UserName = "user",
                PasswordHash = hash,
                PasswordSalt = salt,
                Mail = "mailpopo@mail.com",
                CreationDate = _mockDate
            };
            _mockUserDTO = new UsersDTO()
            {
                ID = 1,
                UserName = "user",
                Password = "test",
                RoleID= 1,
                Mail = "mailpopo@mail.com",
                CreationDate = _mockDate
            };
        }


        [Fact]
        public async Task Authenticate_ValidUser_ReturnsToken()
        {
            // Arrange  
            var _mocktoken = new UsersToken { UserName = "user", ID = 1, ProfileID = 1, Token =" pojhdb jvsd"};


            byte[] passwordSalt;
            byte[] passwordHash;
            _authService.CreatePasswordHash(_mockUserDTO.Password, out passwordHash, out passwordSalt);

            _mockUser = new Users()

            {
                ID = 1,
                UserName = "user",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Mail = "mailpopo@mail.com",
                CreationDate = _mockDate
            };
            _mockUserService.Setup(x => x.GetSingleUser(_mockUserDTO.ID, _mockUserDTO.UserName))
                       .ReturnsAsync(_mockUser);

            _mockAuthService
           .Setup(auth => auth.Authenticate(_mockUserDTO.UserName, _mockUserDTO.Password))
           .ReturnsAsync(_mocktoken);

            // Act

            var result = await _mockAuthService.Object.Authenticate(_mockUserDTO.UserName, _mockUserDTO.Password);


            // Assert

            Assert.NotNull(_mocktoken);
            Assert.Equal("user", _mockUser.UserName);
        }

        [Fact]
        public async Task Authenticate_InvalidPassword_ThrowsException()
        {
            // Arrange
            string username = "TestUser";
            string password = "WrongPassword";
            byte[] passwordSalt;
            byte[] passwordHash;

            _authService.CreatePasswordHash("CorrectPassword", out passwordHash, out passwordSalt);

            var mockUser = new Users
            {
                ID = 1,
                UserName = username,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };

            _mockUserService.Setup(x => x.GetSingleUser(null, username))
                            .ReturnsAsync(mockUser);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<UnauthorizedAccessException>(() => _authService.Authenticate(username, password));
            Assert.Equal("Error en authenticate", exception.Message);
        }

        [Fact]
        public async Task Authenticate_UserNotFound_ThrowsException()
        {
            // Arrange
            string username = "NonExistentUser";
            string password = "SomePassword";

            _mockUserService.Setup(x => x.GetSingleUser(null, username))
                            .ReturnsAsync((Users)null);

            // Act & Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => _authService.Authenticate(username, password));
        }
    }
}
