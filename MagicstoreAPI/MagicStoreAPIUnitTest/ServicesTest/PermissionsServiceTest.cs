using System.Security;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Repositories;
using MagicstoreAPI.Repositories.Interfaces;
using MagicstoreAPI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;


namespace MagicStoreAPIUnitTest;

public class PermissionsServiceTest
{
    public Mock<IPermissionsRepository> _mockPermissionsRepository;
    public Mock<ILogger<PermissionsService>> _mockPermissionLogger;
    public ServiceCollection serviceCollection;
    public IPermissionsService _ipermissionService;
    public Permissions _mockPermission;
    public string _mockEexceptionMessage;
    public PermissionsServiceTest()
   
    {
        _mockPermissionsRepository = new Mock<IPermissionsRepository>();
        _mockPermissionLogger = new Mock<ILogger<PermissionsService>>();
      
        serviceCollection = new ServiceCollection();
        serviceCollection.AddScoped<IPermissionsService, PermissionsService>(x => {
            return new PermissionsService(_mockPermissionLogger.Object,
                _mockPermissionsRepository.Object);
        });
        _ipermissionService = serviceCollection.BuildServiceProvider().GetRequiredService<IPermissionsService>();

        var _mockresult = new Permissions();
        _mockPermission = new Permissions()
        {
            ID = 1,
            Description = "Vales mierda",
            Permission = 1
        };
         _mockEexceptionMessage = "Database error";


    }


    [Fact]
    public async void GetSinglePermissionMethodWithSuccessfulResult()
    {
        _mockPermissionsRepository.Setup(x => x.GetPermissionValue(It.IsAny<int>()))
            .Returns(Task.FromResult(_mockPermission));

        var testResult = await _ipermissionService.GetSinglePermission(1);

        Assert.Equal(testResult.ID, 1);
        Assert.Equal(testResult.Description, "Vales mierda");
        Assert.Equal(testResult.Permission, 1);
    }

    [Fact]
    public async void CreateNewPermissionMethodWithSuccessfulResult()
    { 
        _mockPermissionsRepository.Setup(x => x.CreateNewPermissionRepo(It.IsAny<Permissions>()))
            .Returns(Task.FromResult(_mockPermission));

        var testResult = await _ipermissionService.CreateNewPermission(_mockPermission);

        Assert.Equal(testResult, true);

    }

    [Fact]
    public async void CreateNewPermissionMethodWithFailResult()
    {


        _mockPermissionsRepository.Setup(x => x.CreateNewPermissionRepo(It.IsAny<Permissions>()))
            .ThrowsAsync(new Exception(_mockEexceptionMessage));

        var exception1 = await Assert.ThrowsAsync<Exception>(() => _ipermissionService.CreateNewPermission(_mockPermission));

        Assert.Equal(exception1.Message, _mockEexceptionMessage);

    }

    [Fact]
    public async Task UpdatePermissionService_ShouldReturnTrue_WhenUpdateIsSuccessful()
    {

        // Arrange
        _mockPermissionsRepository.Setup(x => x.UpdatePermissionRepo(It.IsAny<Permissions>()))
            .ReturnsAsync(_mockPermission); // Simula una actualización exitosa que devuelve el permiso actualizado

        // Act
        var result = await _ipermissionService.UpdatePermissionService(_mockPermission);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task UpdatePermissionService_ReturnsFalse_WhenRepositoryReturnsNull()
    {

        // Arrange
        _mockPermissionsRepository.Setup(x => x.UpdatePermissionRepo(It.IsAny<Permissions>()))
            .ReturnsAsync((Permissions)null); 

        // Act
        var result = await _ipermissionService.UpdatePermissionService(_mockPermission);

        // Assert
        Assert.False(result );
        
    }

    [Fact]
    public async Task PermissionsService_DeletePermissionService_Succes ()
    {
        // Arrange
        //Aqui simulamos  que nuestro repo nos da el resultado que requiere  para nuestro test//
        _mockPermissionsRepository.Setup(x => x.DeletePermissionRepo(It.IsAny<int>()))
            .ReturnsAsync(_mockPermission);
        // Act//
        // aqui es donde se ejecuta el metod? //
        var result = await _ipermissionService.DeletePermissionService(_mockPermission.ID);

        // Assert
        //En el asert comprobamos que el resultado obtenido al ejecutar el metodo sea igual que el que estamos esperando//
        Assert.True(result);

    }

}
