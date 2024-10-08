using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Levels.Queries.Models;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    //[Authorize(Roles = "admin")]
    [ApiController]
    public class LevelController(IMediator mediator) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        #endregion

        #region Handle Functions

        [HttpGet("List")]
        public async Task<ActionResult<Response<List<GetLevelResponse>>>> GetLevelsList()
        {
            return Ok(await _mediator.Send(new GetLevelsListQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Response<GetLevelResponse>>> GetLevelById(int Id)
        {
            var response = await _mediator.Send(new GetLevelByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }
        #endregion
    }
}