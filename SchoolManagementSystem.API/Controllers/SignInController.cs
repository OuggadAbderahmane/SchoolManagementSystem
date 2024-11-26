using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Authentication.Commands.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SignInController(IMediator mediator) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        #endregion

        #region Handle Functions
        [HttpPost("ByUserName")]
        public async Task<ActionResult<Response<string>>> SignInByUserNameAsync(SignInByUserNameCommand signInByUser)
        {
            var response = await _mediator.Send(signInByUser);
            if (response.Succeeded)
                return Ok(response);
            return Unauthorized(response);
        }

        [HttpGet("RefreshAccessToken")]
        public async Task<ActionResult<Response<string>>> RefreshAccessTokenAsync()
        {
            var response = await _mediator.Send(new RefreshTokenCommand());
            if (response.Succeeded)
                return Ok(response);
            return Unauthorized(response);
        }

        [HttpGet("Logout")]
        [Authorize(Roles = "user,admin,hr")]
        public async Task<ActionResult<Response<string>>> Logout()
        {
            var response = await _mediator.Send(new LogoutCommand());
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion
    }
}