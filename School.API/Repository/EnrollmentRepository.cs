using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.API.Data;
using School.API.Dtos.Enrollment;
using School.API.Helpers;
using School.API.Interfaces;
using School.API.Mappers;
using School.API.Models;

namespace School.API.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _context;
        public EnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Enrollment>> GetAllAsync(EnrollmentQueryObject query)
        {
            var enrollments = _context.Enrollments.AsQueryable();

            if (query.StudentId != null)
            {
                enrollments = enrollments.Where(e => e.StudentId == query.StudentId);
            }
            if (query.ClassId != null)
            {
                enrollments = enrollments.Where(e => e.ClassId == query.ClassId);
            }
            if (query.IsActive != null)
            {
                enrollments = enrollments.Where(e => e.IsActive == query.IsActive);
            }
            if (query.EnrollmentDate != null)
            {
                enrollments = enrollments.Where(e => e.EnrollmentDate == query.EnrollmentDate);
            }
            if (query.Grade != null)
            {
                enrollments = enrollments.Where(e => e.Grade == query.Grade);
            }

            if (!string.IsNullOrEmpty(query.Sortby))
            {
                if (query.Sortby.Equals("StudentId", StringComparison.OrdinalIgnoreCase))
                {
                    enrollments = query.IsDescending ? enrollments.OrderByDescending(e => e.StudentId) : enrollments.OrderBy(e => e.StudentId);
                }
                else if (query.Sortby.Equals("ClassId", StringComparison.OrdinalIgnoreCase))
                {
                    enrollments = query.IsDescending ? enrollments.OrderByDescending(e => e.ClassId) : enrollments.OrderBy(e => e.ClassId);
                }
                else if (query.Sortby.Equals("EnrollmentDate", StringComparison.OrdinalIgnoreCase))
                {
                    enrollments = query.IsDescending ? enrollments.OrderByDescending(e => e.EnrollmentDate) : enrollments.OrderBy(e => e.EnrollmentDate);
                }
                else if (query.Sortby.Equals("Grade", StringComparison.OrdinalIgnoreCase))
                {
                    enrollments = query.IsDescending ? enrollments.OrderByDescending(e => e.Grade) : enrollments.OrderBy(e => e.Grade);
                }
            }
            int skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await enrollments.Skip(skipNumber).Take(query.PageSize).ToListAsync();

        }

        public async Task<Enrollment?> GetByIdAsync(int id)
        {
            return await _context.Enrollments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Enrollment> CreateAsync(Enrollment enrollmentModel)
        {
            await _context.AddAsync(enrollmentModel);
            await _context.SaveChangesAsync();

            return enrollmentModel;
        }

        public async Task<Enrollment?> DeleteAsync(int id)
        {
            var enrollmentModel = await _context.Enrollments.FirstOrDefaultAsync(e => e.Id == id);

            if (enrollmentModel == null)
            {
                return null;
            }

            _context.Enrollments.Remove(enrollmentModel);
            await _context.SaveChangesAsync();

            return enrollmentModel;
        }

        public async Task<Enrollment?> UpdateAsync(int id, UpdateEnrollmentDto enrollmentDto)
        {
            var existingEnrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.Id == id);

            if (existingEnrollment == null)
            {
                return null;
            }

            existingEnrollment.IsActive = enrollmentDto.IsActive;
            enrollmentDto.Grade = enrollmentDto.Grade;

            await _context.SaveChangesAsync();

            return existingEnrollment;
        }
    }
}
