using UniversityApiBackend.DataAcces;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class ChapterServices : IChapterServices
    {
        private readonly UniversityDBContext _context;
        private readonly ICourseServices _courseServices;

        public ChapterServices(UniversityDBContext context, ICourseServices courseServices)
        {
            _context = context;
            _courseServices = courseServices;
        }
    }
}
