using AuthorizationAPI.Repository;
using AuthorizationAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Controllers
{


    [Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserModel cust)
        {
            var user = userRepository.Authenticate(cust.username, cust.password);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
        /*[AllowAnonymous]
         [HttpPost("authenticate")]*/
        [HttpPost]
        public IActionResult Authenticate(string username, string password)
        {

            var user = userRepository.Authenticate(username, password);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
        [HttpGet("GetUserDetails")]
        public IActionResult GetUserDetails(string username)
        {
            try
            {
                UserModel result = userRepository.UserDetails(username);

                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }

            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Register/{userid}/{username}/{email}/{password}/{address}")]
        public IActionResult RegisterR(string userid, string username, string email, string password, string address)
        {
            Register register = userRepository.RegisterDetails(userid, username, email, password, address);
            try
            {
                if (register == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(register);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}