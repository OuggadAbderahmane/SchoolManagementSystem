using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Features.Authorization.Queries.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class ClaimController(IMediator mediator) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        #endregion

        [HttpGet("getUserClaims")]
        public async Task<IActionResult> getUserClaimsById(string UserNameOrId)
        {
            var result = await _mediator.Send(new GetUserClaimsQuery(UserNameOrId));
            if (result.Succeeded)
                return Ok();
            return NotFound(result);
        }
    }
}