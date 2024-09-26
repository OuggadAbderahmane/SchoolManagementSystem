using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Features.Semesters.Queries.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [Authorize(Roles = "admin")]
    [ApiController]
    public class SemesterController(IMediator mediator) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        #endregion

        #region Handle Functions

        [HttpGet("List")]
        public async Task<IActionResult> GetSemestersList()
        {
            return Ok(await _mediator.Send(new GetSemestersListQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSemesterById(int Id)
        {
            var response = await _mediator.Send(new GetSemesterByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }
        #endregion
    }
}