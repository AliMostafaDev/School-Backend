using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using School.API.Dtos.Class;
using School.API.Helpers;
using School.API.Interfaces;
using School.API.Mappers;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        public readonly IClassRepository _classRepo;
        public readonly ITeacherRepository _teacherRepo;
        public ClassController(IClassRepository classRepo, ITeacherRepository teacherRepo)
        {
            _classRepo = classRepo;
            _teacherRepo = teacherRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]ClassQueryObject query)
        {
            var classes =  await _classRepo.GetAllAsync(query);
            var classesDto = classes.Select(c => c.ToClassDto());
            return Ok(classesDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var classModel = await _classRepo.GetByIdAsync(id);

            if (classModel == null)
            {
                return NotFound("Class does not exist");
            }

            return Ok(classModel.ToClassDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClassDto createClassDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _teacherRepo.TeachertExists(createClassDto.TeacherId))
            {
                return BadRequest("Teacher does not exist");
            }

            var classModel = createClassDto.ToClassFromCreateDto();
            
            await _classRepo.CreateAsync(classModel);

            return CreatedAtAction(nameof(GetById), new {Id =  classModel.Id}, classModel.ToClassDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateClassDto updateClassDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classModel = await _classRepo.UpdateAsync(id, updateClassDto);

            if (classModel == null)
            {
                return NotFound("Class does not exist");
            }

            return Ok(classModel.ToClassDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var classModel = await _classRepo.DeleteAsync(id);

            if (classModel == null)
            {
                return NotFound("Class does not exist");
            }

            return Ok("Class has been deleted!");
        }
    }
}
