using ClgManagementServer.Models;
using ClgManagementServer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClgManagementServer.Controllers
{

    /// <summary>
    /// College management operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeController : ControllerBase
    {
        public readonly IDegreeServices _degreeServices;

        public DegreeController(IDegreeServices degreeServices)
        {
            _degreeServices = degreeServices;
        }



        /// <summary>
        /// Create a new degree
        /// </summary>
        /// <param name="degree">Degree creation details</param>
        /// <returns>Confirmation message</returns>
        /// <response code="200">Degree successfully created</response>
        /// <response code="400">If the request is invalid</response>
        [HttpPost]
        public async Task<IActionResult> CreateNewDegree([FromBody] Degree degree)
        {
            if (degree == null)
                return BadRequest("Invalid Degree Data");

            await _degreeServices.CreateDegree(degree);
            return Ok(new { message = "Degree Successfully Created" });

        }

        /// <summary>
        /// Get all degrees
        /// </summary>
        /// <returns>List of all available degrees</returns>
        /// <response code="200">Returns the list of degrees</response>
        /// <response code="404">If no degrees are found</response>
        [HttpGet("Get All")]
        public async Task<ActionResult<List<Degree>>> GetDegreeData()
        {
            var degreeData = await _degreeServices.GetDegreeData();

            if (degreeData == null || degreeData.Count == 0)
                return NotFound("No degrees found");

            return Ok(degreeData);
        }

        /// <summary>
        /// Get a degree by ID
        /// </summary>
        /// <param name="id">The ID of the degree</param>
        /// <returns>Degree details</returns>
        /// <response code="200">Returns the degree with the given ID</response>
        /// <response code="404">If the degree with the given ID is not found</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Degree>> GetDegreeById(string id)
        {
            var degree = await _degreeServices.GetDegreeById(id);

            if (degree == null)
                return NotFound($"Degree with ID {id} not found");

            return Ok(degree);
        }





    }
}
