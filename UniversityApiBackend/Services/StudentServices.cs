using System.Xml.Linq;
using UniversityApiBackend.DataAcces;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly UniversityDBContext _context;
        private readonly ICourseServices _courseServices;

        public StudentServices(UniversityDBContext context, ICourseServices courseServices)
        {
            _context = context;
            _courseServices = courseServices;
        }

        public List<Student> GetStudentByAge()
        {
            var actualDate = DateTime.Today;
            return _context.Students.Where(x => (actualDate - x.DoB).TotalDays / 365.25 > 18).ToList();
        }
        public List<Student> GetAllEnabledStudents()
        {
            return _context.Students.Where(x => x.IsDeleted == false).ToList();
        }
        public List<Student> GetAllStudentWithOutCourses()
        {
            var CoursesWithStudents = _courseServices.GetCoursesWhitAnyStudent();
            var Students = GetAllEnabledStudents();
            var StudentsInCourses = CoursesWithStudents.SelectMany(c => c.Student).ToList();
            var StudentsWithoutCourses = Students.Where(s => !StudentsInCourses.Contains(s)).ToList();
            return StudentsWithoutCourses;
        }

        public ICollection<Student> GetStudentsByCourseName(string CourseName) {
            return _courseServices.GetCoursesByName(CourseName).Student;
        }

   
    }
}
