using UniversityApiBackend.DataAcces;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly UniversityDBContext _context;

        public CategoryServices(UniversityDBContext context)
        {
            _context = context;
        }

        public Category GetCategoryByName(string CategoryName) {

            return _context.Categories.Where(x => x.Name == CategoryName).FirstOrDefault();
        }

    }
}
