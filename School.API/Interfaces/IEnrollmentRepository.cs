using School.API.Dtos.Enrollment;
using School.API.Helpers;
using School.API.Models;

namespace School.API.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<List<Enrollment>> GetAllAsync(EnrollmentQueryObject query);
        Task<Enrollment?> GetByIdAsync(int id);
        Task<Enrollment> CreateAsync(Enrollment enrollmentModel);
        Task<Enrollment?> DeleteAsync(int id);
        Task<Enrollment?> UpdateAsync(int id, UpdateEnrollmentDto enrollmentDto);
    }
}
