using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MS.DomainLayer.Dtos;
using MS.DomainLayer.Services.Interfaces;
using MS.InfrastructureLayer.Entities;
using System.Data;

namespace MS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var Students = await _studentService.GetAllStudentsAsync();
            var StudentDtos = _mapper.Map<IEnumerable<StudentDto>>(Students);
            return Ok(StudentDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var Student = await _studentService.GetStudentByIdAsync(id);
            if (Student == null)
                return NotFound();

            var studentDto = _mapper.Map<StudentDto>(Student);
            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _studentService.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, studentDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentDto studentDto)
        {
            if (id != studentDto.Id)
                return BadRequest();

            var Student = _mapper.Map<Student>(studentDto);
            await _studentService.UpdateStudentAsync(Student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            return NoContent();
        }
    }
}
