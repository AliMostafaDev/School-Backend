using School.API.Dtos.Comment;
using School.API.Models;

namespace School.API.Dtos.Class
{
    public class ClassDto
    {
        public int Id { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public short Year { get; set; }
        public int? TeacherId { get; set; }
        public int CourseId { get; set; }
    }
}
