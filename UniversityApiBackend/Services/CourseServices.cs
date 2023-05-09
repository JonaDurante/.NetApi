using UniversityApiBackend.DataAcces;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly UniversityDBContext _context;
        private readonly ICategoryServices _categoryServices;
        public CourseServices(UniversityDBContext context, ICategoryServices categoryServices)
        {
            _context = context;
            _categoryServices = categoryServices;
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
        public List<Course> GetAllCoursesByCategory(string CategoryName)
        {
            var ConcretCategory = _categoryServices.GetCategoryByName(CategoryName);
            return _context.Courses.Where(x => x.Categories == ConcretCategory).ToList();
        }

        public List<Course> GetAllCoursesWithoutChapter()
        {
            return _context.Courses.Where(x => x.Chapter == null).ToList(); 
        }

        public Course GetCoursesByName(string CourseName)
        {
            return _context.Courses.Where(x => x.Name == CourseName).FirstOrDefault();
        }

        public string GetTemario(string CourseName) {
            return GetCoursesByName(CourseName).Description;
        }

        public List<Course> GetCoursesByStudent(Student Student)
        {
            return _context.Courses.Where(x => x.Student == Student).ToList();
        }
    }
}
