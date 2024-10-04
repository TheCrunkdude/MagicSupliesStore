using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MagicstoreAPI.Controllers
{
	public class UserController: Controller 
	{
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        // Metodo get, para obtener el valor de nuestra tabla//
        [Route("GetUsers")]
            [HttpGet]
            public async Task<List<Users>> GetUsers()
            {
                List<Users> result = _userService.GetUsers().Result;
                return (result);

            }
        
	}
}

