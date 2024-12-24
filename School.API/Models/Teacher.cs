using System.Linq.Expressions;

namespace School.API.Models
{
    public class Teacher : Person
    {
        

        public int DepartmentId {  get; set; }
        public Department Department { get; set; }

        public ICollection<Class> Classes { get; set; } = new List<Class>();
    }
}
