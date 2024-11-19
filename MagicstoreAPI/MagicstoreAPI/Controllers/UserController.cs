﻿using System;
using MagicstoreAPI.Infrastructures;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using MagicstoreAPI.Interfaces;


namespace MagicstoreAPI.Controllers
{
    [ApiController]
	public class UserController: Controller 
	{
        private IUserService _iuserService;
        public UserController(IUserService iuserService)
        {
            _iuserService = iuserService;
        }
        // Metodo get, para obtener el valor de nuestra tabla//
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
        public async Task<string> CreateNewUser(Users user)
        {
            var result = _iuserService.CreateNewUserService(user).Result;
            var result2 = result == false ? "El empleado ya existe" : "Empleado creado";
            return result2;
        }

        // Metodo put, para actualizar usuario//
        [Route("/api/UpdateUser")]
        [HttpPut]
        public async Task<string> UpdateUser(Users user)
        {
            var result = _iuserService.UpdateUserService(user).Result;
            var result2 = result == false ? "El Usuario no puede ser actualizado" : "Usuario actualizado";
            return result2;
        }

        // Metodo delete, para eliminar usuario//
        [Route("/api/DeleteUser")]
        [HttpDelete]
        public async Task<string> DeleteUser([FromQuery] int ID )
        {

            var result = _iuserService.DeleteUserService(ID).Result;
            var result2 = result == false ? "Usuario no eliminado" : "Usuario eliminado";
            return result2;
        }


    }
}

