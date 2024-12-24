namespace School.API.Helpers
{
    public class ClassQueryObject
    {
        public string? ClassName { get; set; } = null;
        public short? Year { get; set; } = null;
        public int? TeacherId { get; set; } = null;
        public int? CourseId { get; set; } = null;

        public string ? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
