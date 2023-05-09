using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface ICategoryServices
    {
        public Category GetCategoryByName(string CategoryName);
    }
}