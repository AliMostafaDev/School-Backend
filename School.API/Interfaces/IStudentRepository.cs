using School.API.Dtos.Student;
using School.API.Helpers;
using School.API.Models;

namespace School.API.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync(StudentQueryObject query);
        Task<Student?> GetByIdAsync(int id);
        Task<Student> CreateAsync(Student studentModel);
        Task<Student?> UpdateAsync(int id, UpdateStudentRequestDto studentDto);
        Task<Student?> DeleteAsync(int id);
        Task<bool> StudentExists(int id);
    } 
}
