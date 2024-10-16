using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicstoreAPI.Infrastructures;
using MagicstoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MagicstoreAPI.Controllers
{

    [Route("api/[controller]")]

    public class LoginController : Controller
    {
        private AuthenticationService _authenticationService;
        public LoginController(AuthenticationService authenticationService)
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
            string mensaje = await _authenticationService.Authenticate(loginModel.User, loginModel.Password);

            return Ok(mensaje);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

