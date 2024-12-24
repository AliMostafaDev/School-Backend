namespace School.API.Dtos.Enrollment
{
    public class UpdateEnrollmentDto
    {
        public bool IsActive { get; set; }
        public string Grade { get; set; } = string.Empty;
    }
}
