using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Years.Commands.Models;
using SchoolManagementSystem.Core.Features.Years.Queries.Models;
using SchoolManagementSystem.Core.Resources;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class YearController(IMediator mediator, IStringLocalizer<SharedResource> stringLocalizer) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer = stringLocalizer;
        #endregion

        #region Handle Functions
        [HttpGet("PaginatedList")]
        public async Task<IActionResult> GetYearsPaginatedList(int? pageNumber, int? pageSize)
        {
            return Ok(await _mediator.Send(new GetYearsPaginatedListQuery(pageNumber, pageSize)));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetYearById(int Id)
        {
            var response = await _mediator.Send(new GetYearByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddYear(AddYearCommand addYear)
        {
            var response = await _mediator.Send(addYear);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateYear(UpdateYearCommand updateYear)
        {
            var response = await _mediator.Send(updateYear);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion

    }
}