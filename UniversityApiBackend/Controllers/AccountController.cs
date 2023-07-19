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
        //lista para pruebas // --> Volar.
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
        //---


        [HttpPost]
        public IActionResult GetToken(UserLoggin userLoggin)
        {
            try
            {
                //Agregar context de usuario.
                var Token = new UserToken();
                var searchedUser = _context.Users.Where(us =>
                    us.Name.Equals(userLoggin.UserName, StringComparison.OrdinalIgnoreCase) &&
                    us.Password.Equals(userLoggin.Password, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

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
            return Ok(Logins);
        }

    }
}
