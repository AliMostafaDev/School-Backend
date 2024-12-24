using School.API.Dtos.Comment;
using School.API.Models;

namespace School.API.Dtos.Student
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public List<EnrollmentDto> Enrollments { get; set; } = new List<EnrollmentDto>();
    }
}
