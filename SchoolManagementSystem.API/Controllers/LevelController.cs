using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Features.Levels.Queries.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class LevelController(IMediator mediator) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        #endregion

        #region Handle Functions

        [HttpGet("List")]
        public async Task<IActionResult> GetLevelsList()
        {
            return Ok(await _mediator.Send(new GetLevelsListQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetLevelById(int Id)
        {
            var response = await _mediator.Send(new GetLevelByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }
        #endregion
    }
}