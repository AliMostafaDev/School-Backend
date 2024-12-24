using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.API.Dtos.Enrollment;
using School.API.Helpers;
using School.API.Interfaces;
using School.API.Mappers;

namespace School.API.Controllers
{
    [Route("api/Enrollments")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly IClassRepository _classRepo;
        public EnrollmentController(IEnrollmentRepository enrollmentRepo, IStudentRepository studentRepo, IClassRepository classRepo)
        {
            _enrollmentRepo = enrollmentRepo;
            _studentRepo = studentRepo;
            _classRepo = classRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]EnrollmentQueryObject query)
        {
            var enrollments = await _enrollmentRepo.GetAllAsync(query);
            var enrollmentsDto = enrollments.Select(e => e.ToEnrollmentDto());
            return Ok(enrollmentsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var enrollment = await _enrollmentRepo.GetByIdAsync(id);

            if (enrollment == null)
            {
                return NotFound("Enrollment does not exist");
            }

            return Ok(enrollment.ToEnrollmentDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEnrollmentDto enrollmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!await _studentRepo.StudentExists(enrollmentDto.StudentId))
            {
                return BadRequest("Student does not exists");
            }
            if (!await _classRepo.ClassExists(enrollmentDto.ClassId))
            {
                return BadRequest("Class does not exists");
            }

            var enrollmentModel = enrollmentDto.ToEnrollmentFromCreateDto();

            await _enrollmentRepo.CreateAsync(enrollmentModel);

            return CreatedAtAction(nameof(GetById), new {Id =  enrollmentModel.Id}, enrollmentModel.ToEnrollmentDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEnrollmentDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var enrollmentModel = await _enrollmentRepo.UpdateAsync(id, updateDto);

            if (enrollmentModel == null)
            {
                return NotFound("Enrollment does not exist");
            }

            return Ok(enrollmentModel.ToEnrollmentDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var enrollmentModel = await _enrollmentRepo.DeleteAsync(id);

            if (enrollmentModel == null)
            {
                return NotFound("Enrollment does not exist");
            }

            return Ok("Enrollment has been deleted!");
        }

    }
}
