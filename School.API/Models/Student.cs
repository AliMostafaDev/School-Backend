namespace School.API.Models
{
    public class Student : Person
    {
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }

}
