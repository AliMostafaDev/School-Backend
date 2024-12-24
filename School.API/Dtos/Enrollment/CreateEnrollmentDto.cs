using System.ComponentModel.DataAnnotations;

namespace School.API.Dtos.Enrollment
{
    public class CreateEnrollmentDto
    {

        [Required(ErrorMessage = "StudentID is required")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "ClassId is required")]
        public int ClassId { get; set; }

        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "ClassName is required")]
        [MinLength(1, ErrorMessage = "ClassName must be at least 1 characters")]
        [MaxLength(2, ErrorMessage = "ClassName cannot be over 2 characters")]
        public string Grade { get; set; } = string.Empty;
    }
}
