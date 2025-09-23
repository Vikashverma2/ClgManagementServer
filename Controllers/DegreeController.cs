using ClgManagementServer.Models;
using ClgManagementServer.Models.RequestModels;
using ClgManagementServer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClgManagementServer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DegreeController : ControllerBase
    {
        public readonly IDegreeServices _degreeServices;

        public DegreeController(IDegreeServices degreeServices)
        {
            _degreeServices = degreeServices;
        }




        [HttpPost]
        public async Task<IActionResult> CreateNewDegree([FromBody] Degree degree)
        {
            if (degree == null)
                return BadRequest("Invalid Degree Data");

            await _degreeServices.CreateDegree(degree);
            return Ok(new { message = "Degree Successfully Created" });

        }


        [HttpGet("get all")]
        public async Task<ActionResult<List<Degree>>> GetDegreeData()
        {
            var degreeData = await _degreeServices.GetDegreeData();

            if (degreeData == null || degreeData.Count == 0)
                return NotFound("No degrees found");

            return Ok(degreeData);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Degree>> GetDegreeById(string id)
        {
            var degree = await _degreeServices.GetDegreeById(id);

            if (degree == null)
                return NotFound($"Degree with ID {id} not found");

            return Ok(degree);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Degree>> UpdateDegree(string id, [FromBody] UpdateDegreeRequest updateDegreeRequest)
        {
            var updateDegree = await _degreeServices.UpdateDegree(id, updateDegreeRequest);

            if (updateDegree == null)
                return NotFound($"Degree with Id {id} not found");
            return Ok(updateDegree);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDegree(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Degree is Requried");

            var response = await _degreeServices.DeleteDegree(id);


            return Ok(new { message = response });
        } 






    }
}
