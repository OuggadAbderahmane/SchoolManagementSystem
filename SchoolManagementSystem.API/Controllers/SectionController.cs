using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Sections.Commands.Models;
using SchoolManagementSystem.Core.Features.Sections.Queries.Models;
using SchoolManagementSystem.Core.Resources;

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

        [HttpGet("List")]
        public async Task<IActionResult> GetSectionsList()
        {
            return Ok(await _mediator.Send(new GetSectionsListQuery()));
        }
        [HttpGet("PaginatedList")]
        public async Task<IActionResult> GetSectionsPaginatedList(int? pageNumber, int? pageSize)
        {
            return Ok(await _mediator.Send(new GetSectionsPaginatedListQuery(pageNumber, pageSize)));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSectionById(int Id)
        {
            var response = await _mediator.Send(new GetSectionByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddSection(AddSectionCommand addSection)
        {
            var response = await _mediator.Send(addSection);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSection(UpdateSectionCommand updateSection)
        {
            var response = await _mediator.Send(updateSection);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion

    }
}