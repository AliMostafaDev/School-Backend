using System.ComponentModel.DataAnnotations;

namespace School.API.Dtos.Class
{
    public class UpdateClassDto
    {
        [Required(ErrorMessage = "ClassName is required")]
        [MinLength(3, ErrorMessage = "ClassName must be at least 3 characters")]
        [MaxLength(20, ErrorMessage = "ClassName cannot be over 20 characters")]
        public string ClassName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Year is required.")]
        public short Year { get; set; }

        [Required(ErrorMessage = "TeacherId is required.")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "CourseId is required.")]
        public int CourseId { get; set; }
    }
}
