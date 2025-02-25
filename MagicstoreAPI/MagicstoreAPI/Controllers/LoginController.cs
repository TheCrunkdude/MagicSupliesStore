using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using MagicstoreAPI.Infrastructures;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MagicstoreAPI.Controllers
{
    [Route("api/[controller]")]

    public class LoginController : Controller
    {
<<<<<<< HEAD
        private AuthenticationService1 _authenticationService;
        public LoginController(AuthenticationService1 authenticationService)
=======
        private IAuthenticationService _authenticationService;
        public LoginController(IAuthenticationService authenticationService)
>>>>>>> main
        {
            _authenticationService = authenticationService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/
        [HttpGet("{id}")]
        public async Task<IActionResult> CheckLogin(int id)
        {
            return Ok("ok") ;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginModel loginModel)
        {
            var mensaje = await _authenticationService.Authenticate(loginModel.User, loginModel.Password);

            return Ok(mensaje);
        }
    }
}

