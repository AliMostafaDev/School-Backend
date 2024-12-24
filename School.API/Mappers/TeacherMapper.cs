using School.API.Dtos.Teacher;
using School.API.Models;

namespace School.API.Mappers
{
    public static class TeacherMapper
    {
        public static TeacherDto ToTeacherDto(this Teacher teacherModel)
        {
            return new TeacherDto
            {
                Id = teacherModel.Id,
                FirstName = teacherModel.FirstName,
                SecondName = teacherModel.SecondName,
                LastName = teacherModel.LastName,
                DateOfBirth = teacherModel.DateOfBirth,
                Gender = teacherModel.Gender,
                Address = teacherModel.Address,
                Email = teacherModel.Email,
                Phone = teacherModel.Phone,
                DepartmentId = teacherModel.DepartmentId
            };
        }

        public static Teacher ToTeacherFromCreateDto(this CreateTeacherDto createTeacherDto)
        {
            return new Teacher
            {
                FirstName = createTeacherDto.FirstName,
                SecondName = createTeacherDto.SecondName,
                LastName = createTeacherDto.LastName,
                DateOfBirth = createTeacherDto.DateOfBirth,
                Gender = createTeacherDto.Gender,
                Address = createTeacherDto.Address,
                Email = createTeacherDto.Email,
                Phone = createTeacherDto.Phone,
                DepartmentId = createTeacherDto.DepartmentId
            };
        }
    }
}
