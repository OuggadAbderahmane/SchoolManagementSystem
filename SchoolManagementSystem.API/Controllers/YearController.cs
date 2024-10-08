using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Years.Commands.Models;
using SchoolManagementSystem.Core.Features.Years.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    //[Authorize(Roles = "admin")]
    [ApiController]
    public class YearController(IMediator mediator, IStringLocalizer<SharedResource> stringLocalizer) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer = stringLocalizer;
        #endregion

        #region Handle Functions
        [HttpGet("PaginatedList")]
        public async Task<ActionResult<Response<PaginatedResult<GetYearResponse>>>> GetYearsPaginatedList(int? pageNumber, int? pageSize)
        {
            return Ok(await _mediator.Send(new GetYearsPaginatedListQuery(pageNumber, pageSize)));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Response<GetYearResponse>>> GetYearById(int Id)
        {
            var response = await _mediator.Send(new GetYearByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }
        [HttpPost]
        public async Task<ActionResult<Response<IdResponse>>> AddYear(AddYearCommand addYear)
        {
            var response = await _mediator.Send(addYear);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }
        [HttpPut]
        public async Task<ActionResult<Response<string>>> UpdateYear(UpdateYearCommand updateYear)
        {
            var response = await _mediator.Send(updateYear);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        //[Authorize(Roles = "admin")]
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Response<string>>> DeleteYear(int Id)
        {
            var response = await _mediator.Send(new DeleteYearCommand(Id));
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion

    }
}