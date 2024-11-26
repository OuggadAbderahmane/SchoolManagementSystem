using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Jobs.Queries.Models;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [Authorize(Roles = "admin,hr")]
    [ApiController]
    public class JobController(IMediator mediator) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        #endregion

        #region Handle Functions

        [HttpGet("List")]
        public async Task<ActionResult<Response<List<GetJobResponse>>>> GetJobsList()
        {
            return Ok(await _mediator.Send(new GetJobsListQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Response<GetJobResponse>>> GetJobById(int Id)
        {
            var response = await _mediator.Send(new GetJobByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }
        #endregion
    }
}
