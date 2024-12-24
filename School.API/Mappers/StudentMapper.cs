using School.API.Dtos.Student;
using School.API.Models;

namespace School.API.Mappers
{
    public static class StudentMapper
    {
        public static StudentDto ToStudentDto(this Student studentModel)
        {
            return new StudentDto
            {
                Id = studentModel.Id,
                FirstName = studentModel.FirstName,
                SecondName = studentModel.SecondName,
                LastName = studentModel.LastName,
                DateOfBirth = studentModel.DateOfBirth,
                Gender = studentModel.Gender,
                Address = studentModel.Address,
                Email = studentModel.Email,
                Phone = studentModel.Phone,
                Enrollments = studentModel.Enrollments.Select(e => e.ToEnrollmentDto()).ToList()
            };
        }

        public static Student ToStudentFromCreateDto(this CreateStudentRequestDto  createStudentDto)
        {
            return new Student
            {
                FirstName = createStudentDto.FirstName,
                SecondName = createStudentDto.SecondName,
                LastName = createStudentDto.LastName,
                DateOfBirth = createStudentDto.DateOfBirth,
                Gender = createStudentDto.Gender,
                Address = createStudentDto.Address,
                Email = createStudentDto.Email,
                Phone = createStudentDto.Phone
            };
        }
    }
}
