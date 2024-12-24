using System.ComponentModel.DataAnnotations;

namespace School.API.Dtos.Teacher
{
    public class CreateTeacherDto
    {
        [Required(ErrorMessage = "FirstName is required")]
        [MinLength(3, ErrorMessage = "FirstName must be at least 3 characters")]
        [MaxLength(20, ErrorMessage = "FirstName cannot be over 20 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "SecondName is required")]
        [MinLength(3, ErrorMessage = "SecondName must be at least 3 characters")]
        [MaxLength(20, ErrorMessage = "SecondName cannot be over 20 characters")]
        public string SecondName { get; set; } = string.Empty;

        [Required(ErrorMessage = "LastName is required")]
        [MinLength(3, ErrorMessage = "LastName must be at least 3 characters")]
        [MaxLength(20, ErrorMessage = "LastName cannot be over 20 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^[MF]$", ErrorMessage = "Gender must be 'M' or 'F'")]
        public char Gender { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [MinLength(5, ErrorMessage = "Address must be at least 5 characters")]
        [MaxLength(50, ErrorMessage = "Address cannot be over 50 characters")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [MinLength(10, ErrorMessage = "Email must be at least 10 characters")]
        [MaxLength(50, ErrorMessage = "Email cannot be over 50 characters")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        [MinLength(6, ErrorMessage = "Phone must be at least 6 characters")]
        [MaxLength(20, ErrorMessage = "Phone cannot be over 20 characters")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "ClassId is required")]
        public int DepartmentId { get; set; }
    }
}
