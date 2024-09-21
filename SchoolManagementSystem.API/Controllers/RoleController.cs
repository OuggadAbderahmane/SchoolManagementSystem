﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Features.Authorization.Commands.Models;
using SchoolManagementSystem.Core.Features.Authorization.Queries.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class RoleController(IMediator mediator) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        #endregion

        #region Handle Functions
        [HttpGet("getUserRoles")]
        public async Task<IActionResult> getUserRoleById(string UserNameOrId)
        {
            var result = await _mediator.Send(new GetUserRolesQuery(UserNameOrId));
            if (result.Succeeded)
                return Ok();
            return NotFound(result);
        }

        [HttpPut("UpdateUserRoles")]
        public async Task<IActionResult> UpdateUserRolesAsync(UpdateUserRolesCommand updateUserRoles)
        {
            await _mediator.Send(updateUserRoles);
            return Ok("Updated Successfully");
        }
        #endregion
    }
}