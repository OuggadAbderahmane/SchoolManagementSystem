using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Authentication.Commands.Models;
using SchoolManagementSystem.Data.Helper;

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
        public async Task<ActionResult<Response<JwtAuthResult>>> SignInByUserNameAsync(SignInByUserNameCommand UserInfo)
        {
            var response = await _mediator.Send(UserInfo);
            if (response.Succeeded)
                return Ok(response);
            return Unauthorized(response);
        }

        [HttpPost("RefreshAccessToken")]
        public async Task<ActionResult<Response<string>>> RefreshAccessTokenAsync(RefreshTokenCommand RefreshToken)
        {
            var response = await _mediator.Send(RefreshToken);
            if (response.Succeeded)
                return Ok(response);
            return Unauthorized(response);
        }
        #endregion
    }
}