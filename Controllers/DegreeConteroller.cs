using ClgManagementServer.Models;
using ClgManagementServer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClgManagementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeConteroller : ControllerBase
    {
        public readonly IDegreeServices _degreeServices;

        public DegreeConteroller(IDegreeServices degreeServices)
        {
            _degreeServices = degreeServices;
        }

        public async Task<IActionResult> CreateNewDegree([FromBody] Degree degree)
        {
            if (degree == null)
                return BadRequest("Invalid Degree Data");

            await _degreeServices.CreateDegree(degree);
            return Ok(new { message = "Degree Successfully" });
        }

    }
}
