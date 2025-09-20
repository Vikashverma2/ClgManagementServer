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
    public class BranchController : ControllerBase
    {
        private readonly IBranchServices _branchServices;

        public BranchController(IBranchServices branchServices)
        {
            _branchServices = branchServices;

        }

        [HttpPost]

        public async Task<IActionResult> CreateNewBranch([FromBody] Branch branch)
        {
            if (branch == null)
                return BadRequest("Invalid Branch Data");

            await _branchServices.CreateBranch(branch);
            return Ok(new { message = "College Branch Created Successfully" });
        }


        [HttpGet]

        public async Task<ActionResult<List<Branch>>> GetBranchData()
        {
            var collegeList = await _branchServices.GetBranchesData();
            return Ok(collegeList);

        }

        [HttpPut("ID")]

        public async Task<ActionResult<Branch>> UpdateBranch(string id, [FromBody] UpdateBranchRequest branchRequest)
        {
            var updateBranch = await _branchServices.UpdateBranchAsync(id, branchRequest);
            if (updateBranch == null)
                return NotFound($"Brnach with ID {id} not Found");

            return Ok(updateBranch);

        }

        [HttpDelete]

        public async Task<IActionResult> DeleteBranch([FromQuery] string brnachId)
        {
            if (string.IsNullOrEmpty(brnachId))
                return BadRequest("College Id Required");

            var response = await _branchServices.DeleteBranch(brnachId);
            return Ok(new { message = response });
        }




    }
}
