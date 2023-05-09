using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface IUserService
    {
        public User GetByMAil(string Email);

        public List<User> GetUserWhitOutCourses();
    }
}