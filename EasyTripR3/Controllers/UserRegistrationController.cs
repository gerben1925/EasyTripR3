using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EasyTripR3.Interface;
using EasyTripR3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyTripR3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IUser _userservices;
        public UserRegistrationController(IUser user)
        {
            _userservices = user;
        }
        // GET: api/<UserController>
        //[HttpGet]
       // public IActionResult Get(string username, string password)
       // {
        //    List<ReturnID> returinfo = new List<ReturnID>();
        //    string hashedPassword = GetMd5Hash(password);
        //    returinfo = _userservices.GetUserLogin(username , hashedPassword);
        //    if(returinfo.Count == 0)
        //    {
       //         return BadRequest("Invalid Username and password");
        //    }
        //    else
        //    {
        //        return Ok("Successfully Login!");
        //    }
            

        //}


        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] UserRegistration sendUserModel)
        {
            try
            {
                Md5Hash md5Hash = new Md5Hash();
                DataSet ds = new DataSet();
                var hashedpass = md5Hash.ComputeMd5Hash(sendUserModel.Password);
                //string hashedPassword = GetMd5Hash(sendUserModel.Password);
                sendUserModel.Password = hashedpass;
                ds = _userservices.PostUserReg(sendUserModel);
                return Ok(new { message = "Data inserted successfully" });
      
            }
            catch (Exception ex)
            {
                // Handle any exception that occurred during the insertion process
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }      

    }
}
