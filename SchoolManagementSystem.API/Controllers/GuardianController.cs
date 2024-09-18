using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Guardians.Commands.Models;
using SchoolManagementSystem.Core.Features.Guardians.Queries.Models;
using SchoolManagementSystem.Core.Resources;

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

        [HttpGet]
        public async Task<IActionResult> GetGuardiansPaginatedList(int? pageNumber, int? pageSize)
        {
            return Ok(await _mediator.Send(new GetGuardiansPaginatedListQuery(pageNumber, pageSize)));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetGuardianById(int Id)
        {
            var response = await _mediator.Send(new GetGuardianByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddGuardian(AddGuardianCommand addGuardian)
        {
            var response = await _mediator.Send(addGuardian);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }
        [HttpPost("AddByExistPerson")]
        public async Task<IActionResult> AddGuardianByExistPerson(AddGuardianByPersonCommand addGuardian)
        {
            var response = await _mediator.Send(addGuardian);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateGuardian(UpdateGuardianCommand updateGuardian)
        {
            var response = await _mediator.Send(updateGuardian);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion
    }
}
