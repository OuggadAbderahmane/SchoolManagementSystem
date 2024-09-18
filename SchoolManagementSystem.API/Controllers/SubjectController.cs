using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Subjects.Commands.Models;
using SchoolManagementSystem.Core.Features.Subjects.Queries.Models;
using SchoolManagementSystem.Core.Resources;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class SubjectController(IMediator mediator, IStringLocalizer<SharedResource> stringLocalizer) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer = stringLocalizer;
        #endregion

        #region Handle Functions
        [HttpGet("List")]
        public async Task<IActionResult> GetSubjectsList()
        {
            return Ok(await _mediator.Send(new GetSubjectsListQuery()));
        }

        [HttpGet("PaginatedList")]
        public async Task<IActionResult> GetSubjectsPaginatedList(int? pageNumber, int? pageSize)
        {
            return Ok(await _mediator.Send(new GetSubjectsPaginatedListQuery(pageNumber, pageSize)));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSubjectById(int Id)
        {
            var response = await _mediator.Send(new GetSubjectByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubject(AddSubjectCommand addSubject)
        {
            var response = await _mediator.Send(addSubject);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubject(UpdateSubjectCommand updateSubject)
        {
            var response = await _mediator.Send(updateSubject);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion
    }
}
