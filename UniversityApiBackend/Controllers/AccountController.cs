using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAcces;
using UniversityApiBackend.Helppers;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UniversityDBContext _context;

        public AccountController(JwtSettings jwtSettings, UniversityDBContext context)
        {
            _jwtSettings = jwtSettings;
            _context = context;

        }

        [HttpPost]
        public IActionResult GetToken(UserLoggin userLoggin)
        {
            try
            {
                //Agregar context de usuario.
                var Token = new UserToken();
                var searchedUser = _context.Users
                    .Where(us =>us.Email == userLoggin.UserName && us.Password == userLoggin.Password)
                    .FirstOrDefault();

                if (searchedUser != null)
                {
                    Token = JwtHelppers.GenerateTokenKey(new UserToken()
                    {
                        UserName = searchedUser.Name,
                        EmailId = searchedUser.Email,
                        Id = searchedUser.Id,
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
            return Ok(_context.Users.Where(x => x.IsDeleted == false).ToList());
        }

    }
}
