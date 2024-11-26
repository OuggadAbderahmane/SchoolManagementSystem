using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Sections.Commands.Models;
using SchoolManagementSystem.Core.Features.Sections.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class SectionController(IMediator mediator, IStringLocalizer<SharedResource> stringLocalizer) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer = stringLocalizer;
        #endregion

        #region Handle Functions

        [Authorize(Roles = "admin,hr")]
        [HttpGet("List")]
        public async Task<ActionResult<Response<List<GetSectionResponse>>>> GetSectionsList([FromQuery] GetSectionsListQuery getSections)
        {
            return Ok(await _mediator.Send(getSections));
        }

        [Authorize(Roles = "admin,hr")]
        [HttpGet("PaginatedList")]
        public async Task<ActionResult<Response<PaginatedResult<GetSectionResponse>>>> GetSectionsPaginatedList(int? pageNumber, int? pageSize)
        {
            return Ok(await _mediator.Send(new GetSectionsPaginatedListQuery(pageNumber, pageSize)));
        }

        [Authorize(Roles = "admin,hr")]
        [HttpGet("{Id}")]
        public async Task<ActionResult<Response<GetSectionResponse>>> GetSectionById(int Id)
        {
            var response = await _mediator.Send(new GetSectionByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin,hr")]
        [HttpPost]
        public async Task<ActionResult<Response<IdResponse>>> AddSection(AddSectionCommand addSection)
        {
            var response = await _mediator.Send(addSection);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }

        [Authorize(Roles = "admin,hr")]
        [HttpPut]
        public async Task<ActionResult<Response<string>>> UpdateSection(UpdateSectionCommand updateSection)
        {
            var response = await _mediator.Send(updateSection);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        [Authorize(Roles = "admin,hr")]
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Response<string>>> DeleteSection(int Id)
        {
            var response = await _mediator.Send(new DeleteSectionCommand(Id));
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion

    }
}