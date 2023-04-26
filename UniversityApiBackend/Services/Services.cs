using UniversityApiBackend.Models.DataModels;
using UniversityApiBackend.DataAcces;

namespace UniversityApiBackend.Services
{
    public class Services
    {
        private readonly UniversityDBContext _context;

        public Services(UniversityDBContext context)
        {
            _context = context;
        }
        public User GetByMAil(string Email) 
        {
            return _context.Users.Where(x => x.Email == Email).First();
        }
        public List<Student> GetStudentByAge() 
        {
            var actualDate = DateTime.Today;
            return _context.Students.Where(x => (actualDate - x.DoB).TotalDays / 365.25 > 18).ToList();            
        }
        public List<Student> GetStudentByCourse()
        {
            return _context.Students.Where(x =>  x.Courses.Count() >= 1 ).ToList();
        }
        public List<Course> GetCoursesWhitAnyStudent() 
        {
            return _context.Courses.Where(x => x.Level == level.Medium && x.Student.Any()).ToList();
        }
        public List<Course> GetCoursesByLevel()
        {
            return _context.Courses.Where(x => x.Level == level.Expert && x.Categories.Any(y => y.Name.Contains("Filosofía"))).ToList();
        }
        public List<Course> GetEmptyCourses()
        {
            return _context.Courses.Where(x => !x.Student.Any()).ToList();
        }
    }
}
