using School.API.Models;

namespace School.API.Dtos.Comment
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public string Grade { get; set; } = string.Empty;
        
    }
}
