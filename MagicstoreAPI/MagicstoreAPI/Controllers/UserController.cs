using System;
using MagicstoreAPI.Infrastructures;
using MagicstoreAPI.Infrastructures.DTO;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MagicstoreAPI.Interfaces;


namespace MagicstoreAPI.Controllers
{
    [ApiController]
	public class UserController: Controller 
	{
<<<<<<< HEAD
        private UserService _userService;
        private AuthenticationService1 _authenticationService;

        public UserController(UserService userService)
=======
        private IUserService _iuserService;
        public UserController(IUserService iuserService)
>>>>>>> main
        {
            _iuserService = iuserService;
        }
        // Metodo get, para obtener el valor de nuestra tabla//
        [Authorize]
        [Route("/api/GetUsers")]
        [HttpGet]
        public async Task<List<Users>> GetUsers()
        {
            List<Users> result = _iuserService.GetUsers().Result;
            return (result);
        }

        [Route ("/api/GetUser")]
        [HttpGet]
        public async Task<Users> GetUser([FromQuery] int? id, [FromQuery] string name)
        {
            Users result = _iuserService.GetSingleUser(id,name).Result;
            return (result);
        }

        // Metodo post, para generar nuevo usuario//
        [Route("/api/PostNewUser")]
        [HttpPost]
        public async Task<string> CreateNewUser(UsersDTO user)
        {
            var result = _iuserService.CreateNewUserService(user).Result;
            var result2 = result == false ? "El empleado ya existe" : "Empleado creado";
            return result2;
        }

        // Metodo put, para actualizar usuario//
        [Route("/api/UpdateUser")]
        [HttpPut]
        public async Task<string> UpdateUser(UsersDTO user)
        {
            var result = _iuserService.UpdateUserService(user).Result;
            var result2 = result == false ? "El Usuario no puede ser actualizado" : "Usuario actualizado";
            return result2;
        }

        // Metodo delete, para eliminar usuario//
        [Authorize]
        [Route("/api/DeleteUser")]
        [HttpDelete]
        public async Task<string> DeleteUser([FromQuery] int ID )
        {

            var result = _iuserService.DeleteUserService(ID).Result;
            var result2 = result == false ? "Usuario no eliminado" : "Usuario eliminado";
            return result2;
        }


        [Route("/api/access")]
        [HttpPost]
        public async Task<IActionResult> getAccessPermissions([FromBody] string userName)
        {
            var permissions = await _authenticationService.AccessPermissions(userName);

            return Ok(permissions);
        }
    }
}

