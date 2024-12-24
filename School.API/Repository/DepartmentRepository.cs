using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using School.API.Data;
using School.API.Dtos.Department;
using School.API.Dtos.Teacher;
using School.API.Helpers;
using School.API.Interfaces;
using School.API.Models;

namespace School.API.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllAsync(DepartmentQueryObject query)
        {
            var departments = _context.Departments.AsQueryable();

            if (!string.IsNullOrEmpty(query.DepartmentName))
            {
                departments = departments.Where(d =>  d.DepartmentName == query.DepartmentName);
            }

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                if (query.SortBy.Equals("DepartmentName"))
                {
                    departments = query.IsDescending ? departments.OrderByDescending(d => d.DepartmentName) : departments.OrderBy(d => d.DepartmentName);
                }
            }

            int skipNumber = (query.PageNumber - 1) * query.PageSize;
            
            return await departments.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }
        public async Task<Department> CreateAsync(Department departmentModel)
        {
            await _context.Departments.AddAsync(departmentModel);
            await _context.SaveChangesAsync();
            
            return departmentModel;
        }

        public async Task<Department?> UpdateAsync(int id, UpdateDepartmentDto departmentDto)
        {
            var existingDepartment = await _context.Departments.FindAsync(id);

            if (existingDepartment == null)
            {
                return null;
            }

            existingDepartment.DepartmentName = departmentDto.DepartmentName;

            await _context.SaveChangesAsync();

            return existingDepartment;
        }

        public async Task<Department?> DeleteAsync(int id)
        {
            var departmentModel = await _context.Departments.FindAsync(id);

            if (departmentModel == null)
            {
                return null;
            }

            _context.Departments.Remove(departmentModel);
            await _context.SaveChangesAsync();

            return departmentModel;
        }

        public async Task<bool> DepartmentExists(int id)
        {
            return await _context.Departments.AnyAsync(x => x.Id == id);
        }

    }
}
