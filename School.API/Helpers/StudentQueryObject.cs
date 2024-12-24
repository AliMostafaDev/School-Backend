using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace School.API.Helpers
{
    public class StudentQueryObject
    {
        public string? FirstName { get; set; } = null;
        public string? SecondName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public int? DepartmentId { get; set; } = null;

        public string ? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        [Range(1, 1000)]
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
