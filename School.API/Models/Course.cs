namespace School.API.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Description {  get; set; }
        public short Credits {  get; set; }

        public ICollection<Class> Classes { get; set; } = new List<Class>();
    }

}
