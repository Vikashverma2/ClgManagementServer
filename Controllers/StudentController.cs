using ClgManagementServer.Models;
using ClgManagementServer.Models.RequestModels;
using ClgManagementServer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClgManagementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewStudent(Student student)
        {
            if (student == null) return BadRequest("Invaild Student Data");

            await _studentServices.CreateStudent(student);
            return Ok("Degree Sussefully Created");
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<Student>>> GetAllStudentData()
        {
            var getStudent = await _studentServices.GetStudentData();
            return Ok(getStudent);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(string id)
        {
            var studentById = await _studentServices.GetStudentById(id);
            return Ok(studentById);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Student>> StudentUpdate(string id, [FromBody] StudentRequest studentRequest)
        {
            var updateStundet = await _studentServices.UpdateStudent(id, studentRequest);
            if (updateStundet == null)
                return NotFound($"Student with id {id} not found");

            return Ok(updateStundet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStundent(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Stundet Id is Required");

            var response = await _studentServices.DeleteStudent(id);
            return Ok(new { message = response });
        }

       





    }
}
