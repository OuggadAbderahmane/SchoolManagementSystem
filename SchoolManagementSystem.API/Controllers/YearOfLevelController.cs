using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.YearOfLevels.Queries.Models;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [Authorize(Roles = "admin")]
    [ApiController]
    public class YearOfLevelController(IMediator mediator) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        #endregion

        #region Handle Functions

        [HttpGet("List")]
        public async Task<ActionResult<Response<List<GetYearOfLevelResponse>>>> GetYearOfLevelsList()
        {
            return Ok(await _mediator.Send(new GetYearOfLevelsListQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Response<GetYearOfLevelResponse>>> GetYearOfLevelById(int Id)
        {
            var response = await _mediator.Send(new GetYearOfLevelByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }
        #endregion
    }
}