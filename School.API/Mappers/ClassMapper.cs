using School.API.Dtos.Class;
using School.API.Models;

namespace School.API.Mappers
{
    public static class ClassMapper
    {
        public static ClassDto ToClassDto (this Class classModel)
        {
            return new ClassDto
            {
                Id = classModel.Id,
                ClassName = classModel.ClassName,
                Year = classModel.Year,
                TeacherId = classModel.TeacherId,
                CourseId = classModel.CourseId,
            };
        }
        
        public static Class ToClassFromCreateDto(this CreateClassDto createClassDto)
        {
            return new Class
            {
                ClassName = createClassDto.ClassName,
                Year = createClassDto.Year,
                TeacherId = createClassDto.TeacherId,
                CourseId = createClassDto.CourseId
            };
        }
    }
}
