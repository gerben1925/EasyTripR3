using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyTripR3.Interface;
using EasyTripR3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyTripR3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginUserController : ControllerBase
    {
        private readonly IUser _userservices;

        public LoginUserController(IUser user)
        {
            _userservices = user;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserLogin u_login)
        {
            try
            {
                Md5Hash md5 = new Md5Hash();
                List<ReturnID> returinfo = new List<ReturnID>();
                var getmd5 = md5.ComputeMd5Hash(u_login.Password);
                u_login.Password = getmd5;
                returinfo = _userservices.GetUserLogin(u_login);
                if (returinfo.Count == 0)
                {
                    return BadRequest("Invalid Username and password");
                }
                else
                {
                    return Ok("Successfully Login!");
                }

            }
            catch (Exception ex)
            {

                // Handle any exception that occurred during the insertion process
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
