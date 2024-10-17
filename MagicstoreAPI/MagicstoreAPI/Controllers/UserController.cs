using System;
using MagicstoreAPI.Infrastructures;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MagicstoreAPI.Controllers
{
    [ApiController]
	public class UserController: Controller 
	{
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        // Metodo get, para obtener el valor de nuestra tabla//
        [Route("/api/GetUsers")]
            [HttpGet]
            public async Task<List<Users>> GetUsers()
            {
                List<Users> result = _userService.GetUsers().Result;
                return (result);

            }

        [Route ("/api/GetUser")]
        [HttpGet]
        public async Task<Users> GetUser([FromQuery] int? id, [FromQuery] string name)
        {
            Users result =  _userService.GetSingleUser(id,name).Result;
            return (result);

        }


        // Metodo post, para generar nuevo usuario//
        [Route("/api/PostNewUser")]
            [HttpPost]
            public async Task<string> CreateNewUser(Users user)
        {

            var result = _userService.CreateNewUserService(user).Result;
            var result2 = result == false ? "El empleado ya existe" : "Empleado creado";

            return result2;
        }

        // Metodo put, para actualizar usuario//
   

    }
}

