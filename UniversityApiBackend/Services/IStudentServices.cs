using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface IStudentServices
    {
        public List<Student> GetStudentByAge();
        public List<Student> GetAllEnabledStudents();
        public List<Student> GetAllStudentWithOutCourses();
        public ICollection<Student> GetStudentsByCourseName(string CourseName);

    }
}