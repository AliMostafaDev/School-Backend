using Microsoft.EntityFrameworkCore;
using School.API.Data;
using School.API.Dtos.Class;
using School.API.Helpers;
using School.API.Interfaces;
using School.API.Models;

namespace School.API.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _context;
        public ClassRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Class>> GetAllAsync(ClassQueryObject query)
        {
            var classes = _context.Classes.AsQueryable();

            if (!string.IsNullOrEmpty(query.ClassName))
            {
                classes = classes.Where(c => c.ClassName.Contains(query.ClassName));
            }
            if (query.Year != null)
            {
                classes = classes.Where(c => c.Year == query.Year);
            }
            if (query.TeacherId != null)
            {
                classes = classes.Where(c => c.TeacherId == query.TeacherId);
            }
            if (query.CourseId != null)
            {
                classes = classes.Where(c => c.CourseId == query.CourseId);
            }

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                if (query.SortBy.Equals("ClassName", StringComparison.OrdinalIgnoreCase))
                {
                    classes = query.IsDescending ? classes.OrderByDescending(c => c.ClassName) : classes.OrderBy(c => c.ClassName);
                }
                else if (query.SortBy.Equals("Year", StringComparison.OrdinalIgnoreCase))
                {
                    classes = query.IsDescending ? classes.OrderByDescending(c => c.Year) : classes.OrderBy(c => c.Year);
                }
                else if (query.SortBy.Equals("TeacherId", StringComparison.OrdinalIgnoreCase))
                {
                    classes = query.IsDescending ? classes.OrderByDescending(c => c.TeacherId) : classes.OrderBy(c => c.TeacherId);
                }
                else if (query.SortBy.Equals("CourseId", StringComparison.OrdinalIgnoreCase))
                {
                    classes = query.IsDescending ? classes.OrderByDescending(c => c.CourseId) : classes.OrderBy(c => c.CourseId);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await classes.Skip(skipNumber).Take(query.PageSize).ToListAsync();

        }

        public async Task<Class?> GetByIdAsync(int id)
        {
            return await _context.Classes.FindAsync(id);         
        }

        public async Task<Class> CreateAsync(Class classModel)
        {
            await _context.Classes.AddAsync(classModel);
            await _context.SaveChangesAsync();
            return classModel;
        }

        public async Task<Class?> UpdateAsync(int id, UpdateClassDto updateClassDto)
        {
            var classModel = await _context.Classes.FindAsync(id);

            if (classModel == null)
            {
                return null;
            }

            classModel.ClassName = updateClassDto.ClassName;
            classModel.Year = updateClassDto.Year;
            classModel.TeacherId = updateClassDto.TeacherId;
            classModel.CourseId = updateClassDto.CourseId;

            await _context.SaveChangesAsync();

            return classModel;
        }

        public async Task<Class?> DeleteAsync(int id)
        {
            var classModel = await _context.Classes.FindAsync(id);

            if (classModel == null)
            {
                return null;
            }

            _context.Classes.Remove(classModel);
            await _context.SaveChangesAsync();

            return classModel;
        }

        public async Task<bool> ClassExists(int id)
        {
            return await _context.Classes.AnyAsync(c => c.Id == id);
        }
    }
}
