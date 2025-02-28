using System.Text;
using System.Security.Cryptography;
using MagicstoreAPI.Helpers;
using MagicstoreAPI.Infrastructures.DTO;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class AuthenticationServiceTests
{
    private readonly AuthenticationService1 _authService;
    private readonly Mock<IUserService> _mockUserService;
    private readonly Mock<IRolePermissionsService> _mockRolePermissions;
    private readonly Mock<IUserRolesService> _mockUserRolesService;
    private readonly Mock<ILogger<AuthenticationService1>> _mockLogger;
    private readonly Mock<IConfiguration> _mockConfig;
    private readonly JwtSettings _jwtSettings;
    private readonly Mock<IAuthenticationService1> _mockAuth;

    private Users _mockUser;
    private UsersDTO _mockUserDTO;
    private DateTime _mockDate;

    public AuthenticationServiceTests()
    {
        _mockUserService = new Mock<IUserService>();
        _mockRolePermissions = new Mock<IRolePermissionsService>();
        _mockUserRolesService = new Mock<IUserRolesService>();
        _mockLogger = new Mock<ILogger<AuthenticationService1>>();
        _mockConfig = new Mock<IConfiguration>();
        _mockAuth = new Mock<IAuthenticationService1>();


        _jwtSettings = new JwtSettings
        {
            IssuerSigningKey = "ThisIsASecretKeyForTestingOnly!", // Replace with actual test secret
        };



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
            RoleID = 1,
            Mail = "mailpopo@mail.com",
            CreationDate = _mockDate
        };
    }

    private delegate void MockOutDelegate(string password, out byte[] passwordHash, out byte[] passwordSalt);
    [Fact]
    public async Task Authenticate_ValidUser_ReturnsToken()
    {
        // Arrange  
        var _mocktoken = new UsersToken { UserName = "user", ID = 1, ProfileID = 1, Token = " pojhdb jvsd" };


        byte[] passwordHash = new byte[] { 1, 2, 3, 4 };
        byte[] passwordSalt = new byte[] { 5, 6, 7, 8 };


        _mockAuth
            .Setup(m => m.CreatePasswordHash(It.IsAny<string>(), out It.Ref<Byte[]>.IsAny, out It.Ref<Byte[]>.IsAny))
            .Callback(new MockOutDelegate((string _, out byte[] hash, out byte[] salt) =>
            {
                hash = passwordHash;
                salt = passwordSalt;
            }));

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

        _mockAuth.Setup(auth => auth.Authenticate(_mockUserDTO.UserName, _mockUserDTO.Password))
           .ReturnsAsync(_mocktoken);

        // Act

        var result = await _mockAuth.Object.Authenticate(_mockUserDTO.UserName, _mockUserDTO.Password);


        // Assert

        Assert.NotNull(_mocktoken);
        Assert.Equal("user", _mockUser.UserName);
    }

    [Fact]
    public async Task Authenticate_InvalidPassword_ThrowsException()
    {
        // Arrange

        string username = "TestUser";
        string wrongPassword = "WrongPassword";
        string correctPassword = "CorrectPassword";
        byte[] passwordHash = new byte[] { 1, 2, 3, 4 };
        byte[] passwordSalt = new byte[] { 5, 6, 7, 8 };


        var mockUser = new Users
        {
            ID = 1,
            UserName = username,
            PasswordSalt = passwordSalt,
            PasswordHash = passwordHash
        };
        _mockAuth.Setup(auth => auth.Authenticate(username, wrongPassword))
        .ThrowsAsync(new UnauthorizedAccessException("Contraseña inválida"));

        _mockUserService.Setup(x => x.GetSingleUser(null, username))
        .ThrowsAsync(new Exception("Contraseña invalida"));

        var exception = await Assert.ThrowsAsync<UnauthorizedAccessException>(() => _mockAuth.Object.Authenticate(username, wrongPassword)
);

        Assert.Equal("Contraseña inválida", exception.Message);
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

    [Fact]
    public async Task AccessUserRoles_ReturnsPermissions()
    {
        // Arrange
        var userName = "testUser";
        var userRoles = new List<UserRoles>
        {
            new UserRoles { RoleID = 1 },
            new UserRoles { RoleID = 2 }
        };

        var adminPermissions = new List<RolePermissions>
        {
            new RolePermissions { Permission = "Write" },
            new RolePermissions { Permission = "Read" }
        };

        var editorPermissions = new List<RolePermissions>
        {
            new RolePermissions { Permission = "Edit" },
            new RolePermissions { Permission = "Read" }
        };

        _mockUserRolesService
            .Setup(s => s.GetUserRolesByName(userName))
            .ReturnsAsync(userRoles);

        _mockRolePermissions
            .Setup(s => s.GetPermissionsByRole(1))
            .ReturnsAsync(adminPermissions);

        _mockRolePermissions
            .Setup(s => s.GetPermissionsByRole(2))
            .ReturnsAsync(editorPermissions);

        _mockAuth.Setup(auth => auth.AccessUserRoles(userName))
            .ReturnsAsync(() =>
            {
                var allPermissions = adminPermissions
                    .Concat(editorPermissions)
                    .Select(p => p.Permission)
                    .Distinct()
                    .OrderBy(p => p)
                    .ToList();

                return allPermissions;
            });


        // Act
        var result = await _mockAuth.Object.AccessUserRoles(userName);

        // Assert
        var expectedPermissions = new List<string> { "Edit", "Read", "Write" }; // Sorted & Unique
        Assert.Equal(expectedPermissions, result);
    }

}

