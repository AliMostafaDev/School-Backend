using School.API.Dtos.Student;
using School.API.Dtos.Teacher;
using School.API.Helpers;
using School.API.Models;

namespace School.API.Interfaces
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllAsync(TeacherQueryObject query);
        Task<Teacher?> GetByIdAsync(int id);
        Task<Teacher> CreateAsync(Teacher teacherModel);
        Task<Teacher?> UpdateAsync(int id, UpdateTeacherDto studentDto);
        Task<Teacher?> DeleteAsync(int id);
        Task<bool> TeachertExists(int id);
    }
}
