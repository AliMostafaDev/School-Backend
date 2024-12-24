using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using School.API.Dtos.Teacher;
using School.API.Helpers;
using School.API.Interfaces;
using School.API.Mappers;

namespace School.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/teachers")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepo;
        public TeacherController(ITeacherRepository teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TeacherQueryObject query)
        {
            var teachers = await _teacherRepo.GetAllAsync(query);
            var teachersDto = teachers.Select(t => t.ToTeacherDto());

            return Ok(teachersDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var teacher = await _teacherRepo.GetByIdAsync(id);

            if (teacher == null)
            {
                return NotFound("Teacher does not exist");
            }

            return Ok(teacher.ToTeacherDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTeacherDto createTeacherDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacherModel = createTeacherDto.ToTeacherFromCreateDto(); 
            await _teacherRepo.CreateAsync(teacherModel);

            return CreatedAtAction(nameof(GetById), new {Id = teacherModel.Id}, teacherModel.ToTeacherDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTeacherDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacherModel = await _teacherRepo.UpdateAsync(id, updateDto);

            if (teacherModel == null)
            {
                return NotFound("Teacher does not exist");
            }

            return Ok(teacherModel.ToTeacherDto());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var teacherModel = await _teacherRepo.DeleteAsync(id);

            if (teacherModel == null)
            {
                return NotFound("Teacher does not exist");
            }

            return Ok("Teacher has been deleted!");
        }
    }
}
