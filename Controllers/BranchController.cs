using ClgManagementServer.Models;
using ClgManagementServer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClgManagementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchCourse _branchCourse;

        public BranchController(IBranchCourse branchCourse)
        {
            _branchCourse = branchCourse;

        }

        [HttpPost]

        public async Task<IActionResult> CreateNewBranch([FromBody] Branch branch)
        {
            if (branch == null)
             return BadRequest("Invalid Branch Data")
        }

    }
}
