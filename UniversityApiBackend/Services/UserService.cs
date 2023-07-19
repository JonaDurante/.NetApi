using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using UniversityApiBackend.DataAcces;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class UserService : IUserService
    {
        private readonly UniversityDBContext _context;
        private readonly ICourseServices _courseServices;

        public UserService(UniversityDBContext context, ICourseServices courseServices)
        {
            _context = context;
            _courseServices = courseServices;
        }

        public User GetByMAil(string Email)
        {
            return _context.Users.Where(x => x.Email == Email).First();
        }

        public List<User> GetUserWhitOutCourses()
        {
            var Users = _context.Users.Where(x => !x.IsDeleted == false).ToList();
            var Curses = _courseServices.GetCoursesWhitAnyStudent();
            return Users;
        }

        public List<User> GetAll()
        {
            return _context.Users.Where(x => x.IsDeleted == false).ToList();            
        }
    }
}
