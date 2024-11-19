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
    public class RolesServiceTest
    {

        public Mock<IRolesRepository> _mockRolesRepository;
        public Mock<ILogger<RolesService>> _mockRolesLogger;
        public ServiceCollection serviceCollection;
        public IRolesService _iRolesService;
        public List<Roles> _mockList;
        public Roles _mockRole;
        public string _mockEexceptionMessage;

        public RolesServiceTest()
        {
            _mockRolesRepository = new Mock<IRolesRepository>();
            _mockRolesLogger = new Mock<ILogger<RolesService>>();
            _mockList = new List<Roles>();
            _mockEexceptionMessage = "Database error";

            serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IRolesService, RolesService>(x => {
                return new RolesService(_mockRolesLogger.Object,
                    _mockRolesRepository.Object);
            });
            _iRolesService = serviceCollection.BuildServiceProvider().GetRequiredService<IRolesService>();

            _mockRole = new Roles()
            {
                ID = 1,
                PermissionsID = 2,
                Role = "popo"
            };

        }

        [Fact]
        public async void RolesService_GetRoles_Success_Response()
        {
            //arrange

            _mockList.Add(new Roles()
            {
                ID = 1,
                PermissionsID = 2,
                Role = "popo"
            });
            _mockList.Add(new Roles() { ID = 2, PermissionsID = 1, Role = "caca" });

            _mockRolesRepository.Setup(x => x.GetRolesRepo()).Returns(Task.FromResult(_mockList));

            //act
            var testResult = await _iRolesService.GetRoles();
            //assert
            Assert.Equal(testResult, _mockList);
            Assert.InRange(_mockList.Count, 1, 2);
        }


        [Fact]
        public async void RolesService_GetRole_Is_Succcesfull()
        {
            //arrange

            var _mockId = 1;
            _mockRolesRepository.Setup(x => x.GetRoleValue(It.IsAny<int>()))
                .Returns(Task.FromResult(_mockRole));

            //Act
            var testResult = await _iRolesService.GetRoleService(_mockId);

            //Assert//
            Assert.Equal(1, testResult.ID);
            Assert.Equal(2, testResult.PermissionsID);
            Assert.Equal("popo", testResult.Role);

        }

        [Fact]
        public async void RolesService_GetRole_Throw_Error()
        {

            var _mockId = 5;
            string _exception = "Check role Service Error";
            _mockRolesRepository.Setup(x => x.GetRoleValue(It.IsAny<int>()))
                .Returns(Task.FromResult(_mockRole = null));

            //Act
            var testResult = await _iRolesService.GetRoleService(_mockId);

            //Assert//
            Assert.Null(testResult);
        }
        [Fact]
        public async void RolesService_CreateNewRoleService_Success()
        {
            //Arrange
            _mockRolesRepository.Setup(x => x.CreateNewRoleRepo(It.IsAny<Roles>()))
            .Returns(Task.FromResult(_mockRole));

            //Act
            var testResult = await _iRolesService.CreateNewRoleService(_mockRole);

            //Asert
            Assert.True(testResult);
        }
        [Fact]
        public async void RolesService_CreateNewRoleService_ThrowsException()
        {
            //Arrange
            _mockRolesRepository.Setup(x => x.CreateNewRoleRepo(It.IsAny<Roles>()))
            .ThrowsAsync(new Exception(_mockEexceptionMessage));

            //Act
            var rolesexception = await Assert.ThrowsAsync<Exception>(() =>
            _iRolesService.CreateNewRoleService(_mockRole));

            //Asert
            Assert.Equal(_mockEexceptionMessage, rolesexception.Message);
        }

        [Fact]
            public async void RolesService_UpdateRoleService_Success()
            {
            //Arrange
            _mockRolesRepository.Setup(x => x.UpdateRoleRepo(It.IsAny<Roles>()))
            .ReturnsAsync(_mockRole);
            //Act
            var result = await _iRolesService.UpdateRoleService(_mockRole);
            //Asert
            Assert.True(result);
        }
        [Fact]
        public async void RolesService_UpdateRoleService_NotUpdated()
        {
            //Arrange
            _mockRolesRepository.Setup(x => x.UpdateRoleRepo(It.IsAny<Roles>()))
            .ReturnsAsync((Roles)null);
            //Act
            var result = await _iRolesService.UpdateRoleService(_mockRole);
            //Asert
            Assert.False(result);
        }
        [Fact]
        public async void RolesService_DeleteRoleService_Succes()
        {
            //Arrange
            _mockRolesRepository.Setup(x => x.DeleteRoleRepo(It.IsAny<int>()))
            .ReturnsAsync(_mockRole);
            //Act
            var result = await _iRolesService.DeleteRoleService(_mockRole.ID);
            //Asert
            Assert.True(result);
        }
        [Fact]
        public async void RolesService_DeleteRoleService_NotDeleted() 
        {
            //Arrange
            _mockRolesRepository.Setup(x => x.DeleteRoleRepo(It.IsAny<int>()))
            .Returns(Task.FromResult(_mockRole =null));
            //Act
            var result = await _iRolesService.DeleteRoleService(100);
            //Asert
            Assert.False(result);
        }

    }
    }

