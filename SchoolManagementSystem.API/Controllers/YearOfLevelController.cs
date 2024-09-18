using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Features.YearOfLevels.Queries.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class YearOfLevelController(IMediator mediator) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        #endregion

        #region Handle Functions

        [HttpGet("List")]
        public async Task<IActionResult> GetYearOfLevelsList()
        {
            return Ok(await _mediator.Send(new GetYearOfLevelsListQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetYearOfLevelById(int Id)
        {
            var response = await _mediator.Send(new GetYearOfLevelByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }
        #endregion
    }
}