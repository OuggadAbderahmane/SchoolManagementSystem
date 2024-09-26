using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Features.Classes.Queries.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]es")]
    [ApiController]
    public class ClassController(IMediator mediator) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        #endregion

        #region Handle Functions

        [Authorize(Roles = "admin")]
        [HttpGet("List")]
        public async Task<IActionResult> GetClassesList()
        {
            return Ok(await _mediator.Send(new GetClassesListQuery()));
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetClassById(int Id)
        {
            var response = await _mediator.Send(new GetClassByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }
        #endregion
    }
}