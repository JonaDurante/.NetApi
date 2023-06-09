﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApiBackend.Helppers;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        public AccountController(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        private IEnumerable<User> Logins = new List<User>()
        {
            new User () 
            { 
                Id = 1,
                Email= "jona@gmail.com",
                Name = "Admin",
                Password = "Admin"
            },
            new User ()
            {
                Id = 2,
                Email= "pepe@gmail.com",
                Name = "User",
                Password = "pepe"
            }
        };

        [HttpPost]
        public IActionResult GetToken(UserLoggin userLoggin)
        {
            try
            {
                var Token = new UserToken();
                var Valid = Logins.Any(user => user.Name.Equals(userLoggin.UserName, StringComparison.OrdinalIgnoreCase));
                if (Valid)
                {
                    var user = Logins.FirstOrDefault(user => user.Name.Equals(userLoggin.UserName, StringComparison.OrdinalIgnoreCase));
                    Token = JwtHelppers.GenerateTokenKey(new UserToken()
                    {
                        UserName = user.Name,
                        EmailId = user.Email,
                        Id = user.Id,
                        GuidId = Guid.NewGuid(),
                    }, _jwtSettings);
                }
                else 
                {
                    return BadRequest("Wrong credentials");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw new Exception("GetToken error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUsersList()
        { 
            return Ok(Logins);
        }

    }
}
