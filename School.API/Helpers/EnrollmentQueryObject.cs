namespace School.API.Helpers
{
    public class EnrollmentQueryObject
    {
        public int? StudentId { get; set; } = null;
        public int? ClassId { get; set; } = null;
        public bool? IsActive { get; set; } = null;
        public DateTime? EnrollmentDate { get; set; } = null;
        public string? Grade { get; set; } = null;

        public string? Sortby {  get; set; } = null;
        public bool IsDescending { get; set; } = false;

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
