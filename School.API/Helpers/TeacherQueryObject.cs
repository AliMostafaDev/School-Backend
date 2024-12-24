using System.ComponentModel.DataAnnotations;

namespace School.API.Helpers
{
    public class TeacherQueryObject
    {
        public string? FirstName { get; set; } = null;
        public string? SecondName { get; set; } = null;
        public string? LastName { get; set; } = null;

        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        [Range(1, 1000)]
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
