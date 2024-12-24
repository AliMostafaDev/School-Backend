using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.API.Data;
using School.API.Dtos.Student;
using School.API.Helpers;
using School.API.Interfaces;
using School.API.Models;

namespace School.API.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateAsync(Student studentModel)
        {
            await _context.Students.AddAsync(studentModel);
            await _context.SaveChangesAsync();
            
            return studentModel;
        }

        public async Task<Student?> DeleteAsync(int id)
        {
            var studentModel = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

            if (studentModel == null)
            {
                return null;
            }

            _context.Students.Remove(studentModel);
            await _context.SaveChangesAsync();

            return studentModel;
        }

        public async Task<List<Student>> GetAllAsync(StudentQueryObject query)
        {
            var students = _context.Students.Include(s => s.Enrollments).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.FirstName))
            {
                students = students.Where(s => s.FirstName.Contains(query.FirstName));
            }
            if (!string.IsNullOrWhiteSpace(query.SecondName))
            {
                students = students.Where(s => s.SecondName.Contains(query.SecondName));
            }
            if (!string.IsNullOrWhiteSpace(query.LastName))
            {
                students = students.Where(s => s.LastName.Contains(query.LastName));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("FirstName", StringComparison.OrdinalIgnoreCase))
                {
                    students = query.IsDescending ? students.OrderByDescending(s => s.FirstName) : students.OrderBy(s => s.FirstName);
                }
                else if (query.SortBy.Equals("SecondName", StringComparison.OrdinalIgnoreCase))
                {
                    students = query.IsDescending ? students.OrderByDescending(s => s.SecondName) : students.OrderBy(s => s.SecondName);
                }
                else if (query.SortBy.Equals("LastName", StringComparison.OrdinalIgnoreCase))
                {
                    students = query.IsDescending ? students.OrderByDescending(s => s.LastName) : students.OrderBy(s => s.LastName);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await students.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.Include(s => s.Enrollments).FirstOrDefaultAsync(s => s.Id == id);      
        }

        public async Task<bool> StudentExists(int id)
        {
            return await _context.Students.AnyAsync(s => s.Id == id);
        }

        public async Task<Student?> UpdateAsync(int id, UpdateStudentRequestDto studentDto)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.FirstName = studentDto.FirstName;
            existingStudent.SecondName = studentDto.SecondName;
            existingStudent.LastName = studentDto.LastName;
            existingStudent.DateOfBirth = studentDto.DateOfBirth;
            existingStudent.Gender = studentDto.Gender;
            existingStudent.Address = studentDto.Address;
            existingStudent.Email = studentDto.Email;
            existingStudent.Phone = studentDto.Phone;

            await _context.SaveChangesAsync();

            return existingStudent;
        }
    }
}
