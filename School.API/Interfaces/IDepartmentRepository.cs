using School.API.Dtos.Department;
using School.API.Dtos.Teacher;
using School.API.Helpers;
using School.API.Models;

namespace School.API.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync(DepartmentQueryObject query);
        Task<Department?> GetByIdAsync(int id);
        Task<Department> CreateAsync(Department departmentModel);
        Task<Department?> UpdateAsync(int id, UpdateDepartmentDto departmentDto);
        Task<Department?> DeleteAsync(int id);
        Task<bool> DepartmentExists(int id);
    }
}
