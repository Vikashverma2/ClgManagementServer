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
                return BadRequest("Invalid College Data");

            await _collegeService.CreateCollege(college);
            return Ok(new { message = " College Created Successfully", colleges = college });

        }



        [HttpGet("get-all")] 

        public async Task<ActionResult<List<College>>> GetCollegeData()
        {
            var collegeList = await _collegeService.GetCollegesData();
            return Ok(collegeList);
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<College>> GetDegreeById(string id)
        {
            var getCollege = await _collegeService.GetCollegeById(id);

            if (getCollege == null)
                return NotFound($"College with Id {id} not found");

            return Ok(getCollege);
        }

        


        [HttpPut("{id}")]
        public async Task<ActionResult<College>> UpdateCollege(string id, [FromBody] UpdateCollegeRequest request)
        {
            var updateCollege = await _collegeService.UpdateCollegeAsync(id, request);
            if (updateCollege == null)
                return NotFound($"College with ID {id} not found");

            return Ok(updateCollege);
        }



        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCollege(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("College Id required");

            var response = await _collegeService.DeleteCollege(id);
            return Ok(new { message = response });
        }








    }
}
