using MediatR;
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
        [HttpGet]
        public async Task<IActionResult> GetUsersList(int? pageNumber, int? pageSize)
        {
            return Ok(await _mediator.Send(new GetUsersPaginatedListQuery(pageNumber, pageSize)));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            return Ok(await _mediator.Send(new GetUserByIdQuery(Id)));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserCommand addUser)
        {
            var response = await _mediator.Send(addUser);
            if (response.Succeeded)
                return Created("User Created", response);
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand updateUser)
        {
            var response = await _mediator.Send(updateUser);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand changePassword)
        {
            var response = await _mediator.Send(changePassword);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        //[HttpDelete("{Id}")]
        //public async Task<IActionResult> DeleteUser(int Id)
        //{
        //    var response = await _mediator.Send(new DeleteUserCommand(Id));
        //    if (response.Succeeded)
        //        return Ok(response);
        //    return BadRequest(response);
        //}
        #endregion
    }
}