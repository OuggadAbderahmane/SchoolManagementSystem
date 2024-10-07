﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Authorization.Queries.Models;
using SchoolManagementSystem.Data.Responses;

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
        public async Task<ActionResult<Response<GetUserClaimsResponse>>> getUserClaimsById(string UserNameOrId)
        {
            var result = await _mediator.Send(new GetUserClaimsQuery(UserNameOrId));
            if (result.Succeeded)
                return Ok();
            return NotFound(result);
        }
    }
}

// var Id = int.Parse(HttpContext.User.Claims.First(claim => claim.Type == "PersonId").Value);