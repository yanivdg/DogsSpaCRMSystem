using DogsSpaCRMSystem.Server.Data;
using DogsSpaCRMSystem.Server.Intefrace;
using DogsSpaCRMSystem.Server.Model;
using DogsSpaCRMSystem.Server.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DogsSpaCRMSystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AuthService _auth;

        public UserController(AuthService auth)
        {
            _auth = auth;
        }

        // Login action
        [HttpPost("SignIn")]
        public async Task<bool> SignIn(string username, string password)
        {
            // Authenticate user
            return await _auth.SignIn(username, password);
        }

        // Register action
        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUp(string username, string password, string firstname)
        {
            // Register user
            try
            {
                await _auth.SignUp(username, password, firstname);

                return Ok("User registered successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
