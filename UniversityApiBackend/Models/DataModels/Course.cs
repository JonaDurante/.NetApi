using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public enum level
    {
        Basic,
        Medium,
        Advanced,
        Expert
    }
    public class Course : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public level Level { get; set; } = level.Basic;
        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        [Required]
        public Chapter Chapter { get; set; } = new Chapter();
        [Required]
        public ICollection<Student> Student { get; set; } = new List<Student>();

    }
}
