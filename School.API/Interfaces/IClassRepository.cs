using School.API.Dtos.Class;
using School.API.Helpers;
using School.API.Models;

namespace School.API.Interfaces
{
    public interface IClassRepository
    {
        Task<List<Class>> GetAllAsync(ClassQueryObject query);
        Task<Class?> GetByIdAsync(int id);
        Task<Class> CreateAsync(Class classModel);
        Task<Class?> UpdateAsync(int id, UpdateClassDto updateClassDto);
        Task<Class?> DeleteAsync(int id);
        Task<bool> ClassExists(int id);
    }
}
