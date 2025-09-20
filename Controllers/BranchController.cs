using ClgManagementServer.Models;
using ClgManagementServer.Models.RequestModels;
using ClgManagementServer.Services.Interfaces;
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
                return BadRequest("Invalid branch data");

            await _branchServices.CreateBranch(branch);
            return Ok(new { message = "Branch created successfully" });
        }

        [HttpGet]
        public async Task<ActionResult<List<Branch>>> GetBranchData()
        {
            var branchList = await _branchServices.GetBranchesData();
            return Ok(branchList);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Branch>> UpdateBranch(string id, [FromBody] UpdateBranchRequest branchRequest)
        {
            var updateBranch = await _branchServices.UpdateBranchAsync(id, branchRequest);

            if (updateBranch == null)
                return NotFound($"Branch with ID {id} not found");

            return Ok(updateBranch);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Branch Id is required");

            var response = await _branchServices.DeleteBranch(id);

            return Ok(new { message = response });
        }
    }
}
