using Microsoft.EntityFrameworkCore;
using School.API.Dtos.Comment;
using School.API.Dtos.Enrollment;
using School.API.Models;

namespace School.API.Mappers
{
    public static class EnrollmentMapper
    {
        public static EnrollmentDto ToEnrollmentDto(this Enrollment enrollmentModel)
        {
            return new EnrollmentDto
            {
                Id = enrollmentModel.Id,
                StudentId = enrollmentModel.StudentId,
                ClassId = enrollmentModel.ClassId,
                EnrollmentDate = enrollmentModel.EnrollmentDate,
                IsActive = enrollmentModel.IsActive,
                Grade = enrollmentModel.Grade
            };
        }

        public static Enrollment ToEnrollmentFromCreateDto(this CreateEnrollmentDto createEnrollmentDto)
        {
            return new Enrollment
            {
                StudentId = createEnrollmentDto.StudentId,
                ClassId = createEnrollmentDto.ClassId,
                IsActive = createEnrollmentDto.IsActive,
                Grade = createEnrollmentDto.Grade
            };
        }
    }
}
