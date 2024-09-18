using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.FinalExams.Commands.Models;
using SchoolManagementSystem.Core.Features.FinalExams.Queries.Models;
using SchoolManagementSystem.Core.Resources;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class FinalExamController(IMediator mediator, IStringLocalizer<SharedResource> stringLocalizer) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer = stringLocalizer;
        #endregion

        #region Handle Functions
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetFinalExamById(int Id)
        {
            var response = await _mediator.Send(new GetFinalExamByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddFinalExam(AddFinalExamCommand addFinalExam)
        {
            var response = await _mediator.Send(addFinalExam);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFinalExam(UpdateFinalExamCommand updateFinalExam)
        {
            var response = await _mediator.Send(updateFinalExam);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion
    }
}