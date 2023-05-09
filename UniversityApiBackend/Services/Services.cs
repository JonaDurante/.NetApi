using UniversityApiBackend.Models.DataModels;
using UniversityApiBackend.DataAcces;

namespace UniversityApiBackend.Services
{
    public class Services : IServices
    {
        private readonly UniversityDBContext _context;

        public Services(UniversityDBContext context)
        {
            _context = context;
        }
    }
}
