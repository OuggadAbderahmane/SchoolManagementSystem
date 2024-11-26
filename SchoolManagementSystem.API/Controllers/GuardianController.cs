using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Guardians.Commands.Models;
using SchoolManagementSystem.Core.Features.Guardians.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class GuardianController(IMediator mediator, IStringLocalizer<SharedResource> stringLocalizer) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer = stringLocalizer;
        #endregion

        #region Handle Functions

        [Authorize(Roles = "admin,hr")]
        [HttpGet]
        public async Task<ActionResult<Response<PaginatedResult<GetGuardianResponse>>>> GetGuardiansPaginatedList([FromQuery] GetGuardiansPaginatedListQuery getGuardiansPaginatedListQuery)
        {
            return Ok(await _mediator.Send(getGuardiansPaginatedListQuery));
        }

        [Authorize(Roles = "admin,hr")]
        [HttpGet("GetGuardianById/{Id}")]
        public async Task<ActionResult<Response<GetAllGuardianInfoResponse>>> GetGuardianById(int Id)
        {
            var response = await _mediator.Send(new GetGuardianByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        /// <summary>
        /// Only Users have Guardian claim can use it
        /// </summary>
        [Authorize(policy: "GuardianOnly")]
        [Authorize(Roles = "user")]
        [HttpGet("GetGuardian")]
        public async Task<ActionResult<Response<GetAllGuardianInfoResponse>>> GetGuardian()
        {
            var response = await _mediator.Send(new GetGuardianQuery());
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin,hr")]
        [HttpPost("Add")]
        public async Task<ActionResult<Response<IdResponse>>> AddGuardian([FromForm] AddGuardianCommand addGuardian)
        {
            var response = await _mediator.Send(addGuardian);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }

        /// <summary>
        /// If you have a person that already exists and want to make it Guardian
        /// </summary>
        [Authorize(Roles = "admin,hr")]
        [HttpPost("AddByExistPerson")]
        public async Task<ActionResult<Response<string>>> AddGuardianByExistPerson(AddGuardianByPersonCommand addGuardian)
        {
            var response = await _mediator.Send(addGuardian);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }

        [Authorize(Roles = "admin,hr")]
        [HttpPut("Update")]
        public async Task<ActionResult<Response<string>>> UpdateGuardian(UpdateGuardianCommand updateGuardian)
        {
            var response = await _mediator.Send(updateGuardian);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        [Authorize(Roles = "admin,hr")]
        [HttpDelete("Delete/{Id}")]
        public async Task<ActionResult<Response<string>>> DeleteGuardian(int Id)
        {
            var response = await _mediator.Send(new DeleteGuardianCommand(Id));
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion
    }
}
