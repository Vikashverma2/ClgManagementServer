using ClgManagementServer.Models;
using ClgManagementServer.Models.RequestModels;
using ClgManagementServer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ClgManagementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {

        private readonly ICollegeServices _collegeService;

        public CollegeController(ICollegeServices collegeServices)
        {

            _collegeService = collegeServices;

        }

        [HttpPost]

        public async Task<IActionResult> CreateNewCollege([FromBody] College college)
        {

            if (college == null)
                return BadRequest("Invalid Student Data");

            await _collegeService.CreateCollege(college);
            return Ok(new { message = " Student Created Successfully", colleges = college });

        }


        /// <summary>
        /// Get all colleges from the database
        /// </summary>
        /// <returns>List of colleges</returns>
        [HttpGet("Get-All")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<College>>> GetCollegeData()
        {
            var collegeList = await _collegeService.GetCollegesData();
            return Ok(collegeList);
        }

        [HttpPut]
        public async Task<ActionResult<College>> UpdateCollege(string id, [FromBody] UpdateCollegeRequest request)
        {
            var updateCollege = await _collegeService.UpdateCollegeAsync(id, request);
            if (updateCollege == null)
                return NotFound($"College with ID {id} not found");

            return Ok(updateCollege);
        }



        [HttpDelete]

        public async Task<IActionResult> DeleteCollege([FromQuery] string collegeId)
        {
            if (string.IsNullOrEmpty(collegeId))
                return BadRequest("College Id required");

            var response = await _collegeService.DeleteCollege(collegeId);
            return Ok(new { message = response });
        }








    }
}
