using Microsoft.EntityFrameworkCore;
using School.API.Data;
using School.API.Dtos.Teacher;
using School.API.Helpers;
using School.API.Interfaces;
using School.API.Models;

namespace School.API.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> GetAllAsync(TeacherQueryObject query)
        {
            var teachers = _context.Teachers.AsQueryable();

            if (!string.IsNullOrEmpty(query.FirstName))
            {
                teachers = teachers.Where(t => t.FirstName.Contains(query.FirstName));
            }
            if (!string.IsNullOrEmpty(query.SecondName))
            {
                teachers = teachers.Where(t => t.SecondName.Contains(query.SecondName));
            }
            if (!string.IsNullOrEmpty(query.LastName))
            {
                teachers = teachers.Where(t => t.LastName.Contains(query.LastName));
            }

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                if (query.SortBy.Equals("FirstName", StringComparison.OrdinalIgnoreCase))
                {
                    teachers = query.IsDescending ? teachers.OrderByDescending(t => t.FirstName) : teachers.OrderBy(t => t.FirstName);
                }
                else if (query.SortBy.Equals("SecondName", StringComparison.OrdinalIgnoreCase))
                {
                    teachers = query.IsDescending ? teachers.OrderByDescending(t => t.SecondName) : teachers.OrderBy(t => t.SecondName);
                }
                else if (query.SortBy.Equals("LastName", StringComparison.OrdinalIgnoreCase))
                {
                    teachers = query.IsDescending ? teachers.OrderByDescending(t => t.LastName) : teachers.OrderBy(t => t.LastName);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await teachers.Skip(skipNumber).Take(query.PageSize).ToListAsync();

        }

        public async Task<Teacher?> GetByIdAsync(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<Teacher> CreateAsync(Teacher teacherModel)
        {
            await _context.Teachers.AddAsync(teacherModel);
            await _context.SaveChangesAsync();

            return teacherModel;
        }

        public async Task<Teacher?> DeleteAsync(int id)
        {
            var teacherModel = await _context.Teachers.FindAsync(id);

            if (teacherModel == null)
            {
                return null;
            }

            _context.Teachers.Remove(teacherModel);
            await _context.SaveChangesAsync();

            return teacherModel;
        }

        public async Task<Teacher?> UpdateAsync(int id, UpdateTeacherDto teacherDto)
        {
            var teacherModel = await _context.Teachers.FindAsync(id);

            if (teacherModel == null)
            {
                return null;
            }

            teacherModel.FirstName = teacherDto.FirstName;
            teacherModel.SecondName = teacherDto.SecondName;
            teacherModel.LastName = teacherDto.LastName;
            teacherModel.DateOfBirth = teacherDto.DateOfBirth;
            teacherModel.Gender = teacherDto.Gender;
            teacherModel.Address = teacherDto.Address;
            teacherModel.Email = teacherDto.Email;
            teacherModel.Phone = teacherDto.Phone;
            teacherModel.DepartmentId = teacherDto.DepartmentId;

            await _context.SaveChangesAsync();

            return teacherModel;
        }

        public async Task<bool> TeachertExists(int id)
        {
            return await _context.Teachers.AnyAsync(t => t.Id == id);
        }

    }
}
