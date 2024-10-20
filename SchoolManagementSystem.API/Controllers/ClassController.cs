using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Classes.Queries.Models;
using SchoolManagementSystem.Data.Responses;

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

        //[Authorize(Roles = "admin")]
        [HttpGet("List")]
        public async Task<ActionResult<Response<List<GetClassResponse>>>> GetClassesList([FromQuery] GetClassesListQuery getClassesListQuery)
        {
            return Ok(await _mediator.Send(getClassesListQuery));
        }

        //[Authorize(Roles = "admin")]
        [HttpGet("{Id}")]
        public async Task<ActionResult<Response<GetClassResponse>>> GetClassById(int Id)
        {
            var response = await _mediator.Send(new GetClassByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }
        #endregion
    }
}