namespace School.API.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string ClassName {  get; set; } = string.Empty;
        public short Year {  get; set; }

        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    }

}
