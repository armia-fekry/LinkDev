using Microsoft.AspNetCore.Mvc;
using LinkDev.Task.Models;
using LinkDev.Task.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using LinkDev.Task.Application.DTO;

namespace LinkDev.Task.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService=branchService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public async Task<IActionResult> AddBranchAsync([FromBody] BranchPostDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(await _branchService.AddBranchAsync(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("All")]
        public async Task<IActionResult> GetBranchesAsync([FromQuery] BranchesFilterParameter parameter)
        {
            try
            {
                return Ok(await _branchService.GetBranchesAsync(parameter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> AddRoleAsync([FromRoute] string id)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid branchId))
                    return BadRequest("Invalid Branch Id.");

                return Ok(await _branchService.DeleteBranchAsync(branchId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}