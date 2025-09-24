using ClgManagementServer.Models;
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



    }
}
