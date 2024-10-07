using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Features.Users.Commands.Models;
using SchoolManagementSystem.Core.Features.Users.Queries.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        #endregion

        #region Handle Functions

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsersList(int? pageNumber, int? pageSize)
        {
            return Ok(await _mediator.Send(new GetUsersPaginatedListQuery(pageNumber, pageSize)));
        }

        [Authorize(Roles = "admin")]
        [HttpGet("GetUserByNameOrId")]
        public async Task<IActionResult> GetUserByNameOrId(string UserNameOrId)
        {
            var response = await _mediator.Send(new GetUserByNameOrIdQuery(UserNameOrId));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }


        /// <summary>
        /// Only Users have user Role can use it
        /// </summary>
        [Authorize(Roles = "user")]
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var response = await _mediator.Send(new GetUserQuery());
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserCommand addUser)
        {
            var response = await _mediator.Send(addUser);
            if (response.Succeeded)
                return Created("User Created", response);
            return BadRequest(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand updateUser)
        {
            var response = await _mediator.Send(updateUser);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// Both user and admin can change his own password
        /// </summary>
        [Authorize(Roles = "user,admin")]
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(string CurrentPassword, string NewPassword)
        {
            var response = await _mediator.Send(new ChangePasswordCommand { CurrentPassword = CurrentPassword, NewPassword = NewPassword });
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var response = await _mediator.Send(new DeleteUserCommand(Id));
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion
    }
}