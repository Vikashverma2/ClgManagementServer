using ClgManagementServer.Models;
using ClgManagementServer.Models.RequestModels;
using ClgManagementServer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClgManagementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyServices _facultyServices;

        public FacultyController(IFacultyServices facultyServices)
        {
            _facultyServices = facultyServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewFaculty(Faculty faculty)
        {
            await _facultyServices.CreateFaculty(faculty);
            return Ok("Faculty Created Successfully");

        }

        [HttpGet("get-all")]

        public async Task<ActionResult<List<Faculty>>> GetFacultyData()
        {
            var getFaculties = await _facultyServices.GetFacultiesAsync();
            return Ok(getFaculties);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Faculty>> GetFacultyById(string id)
        {
            var getFaculity = await _facultyServices.GetFacultyById(id);

            if (getFaculity == null)
                return NotFound($"Faculty with Id {id} not found");

            return Ok(getFaculity);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Faculty>> FacultyUpdate(string id, [FromBody] FacultyRequest facultyRequest)
        {
            var updateFaculty = await _facultyServices.Updateafaculty(id, facultyRequest);
            if (updateFaculty == null)
                return NotFound($"Faculty with Id {id} not found");

            return Ok(updateFaculty);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteFaculty(string id)
        {
            var deleteFaculty = await _facultyServices.DeleteFaculty(id);

            if (!deleteFaculty)
                return NotFound($"Faculty With ID {id} not found");

            return Ok($"Faculty with id {id} Deleted Successfully");        
        }


    }
}
