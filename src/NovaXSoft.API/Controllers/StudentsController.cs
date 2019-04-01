using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovaXSoft.API.Domain.DTOs.Student;
using NovaXSoft.API.Services.Abstraction;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace NovaXSoft.API.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentsService studentService;

        public StudentsController(IStudentsService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<StudentDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await this.studentService.GetAllStudents();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(StudentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStudentById([Required]int id)
        {
            var result = await this.studentService.GetStudentById(id);
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateStudent([FromBody]StudentDTO studentDTO)
        {
            int studentId = await this.studentService.CreateStudent(studentDTO);
            return Ok(studentId);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteStudent([Required]int id)
        {
            await this.studentService.DeleteStudent(id);

            return NoContent();
        }
    }
}
