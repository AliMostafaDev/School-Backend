using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.API.Data;
using School.API.Dtos.Student;
using School.API.Helpers;
using School.API.Interfaces;
using School.API.Mappers;
using School.API.Models;
using School.API.Repository;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace School.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;

        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] StudentQueryObject query)
        {

            var students = await _studentRepo.GetAllAsync(query);
            var studentsDto = students.Select(s => s.ToStudentDto());
            return Ok(studentsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var student = await _studentRepo.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound("Student does not exist");
            }

            return Ok(student.ToStudentDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentRequestDto createStudenDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var studentModel = createStudenDto.ToStudentFromCreateDto();
            await _studentRepo.CreateAsync(studentModel);

            return CreatedAtAction(nameof(GetById),new {Id =  studentModel.Id}, studentModel.ToStudentDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStudentRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var studentModel = await _studentRepo.UpdateAsync(id, updateDto);

            if (studentModel == null)
            {
                return NotFound("Student does not exist");
            }

            return Ok(studentModel.ToStudentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var studentModel = await _studentRepo.DeleteAsync(id);

            if (studentModel == null)
            {
                return NotFound("Student does not exist");
            }

            return Ok("Student has been deleted!");
        }

    }
}
