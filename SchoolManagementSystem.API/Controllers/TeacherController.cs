using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Teachers.Commands.Models;
using SchoolManagementSystem.Core.Features.Teachers.Queries.Models;
using SchoolManagementSystem.Core.Resources;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class TeacherController(IMediator mediator, IStringLocalizer<SharedResource> stringLocalizer) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer = stringLocalizer;
        #endregion

        #region Handle Functions

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetTeachersPaginatedList(int? pageNumber, int? pageSize)
        {
            return Ok(await _mediator.Send(new GetTeachersPaginatedListQuery(pageNumber, pageSize)));
        }

        [Authorize(Roles = "admin")]
        [HttpGet("GetTeacherById/{Id}")]
        public async Task<IActionResult> GetTeacherById(int Id)
        {
            var response = await _mediator.Send(new GetTeacherByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(policy: "TeacherOnly")]
        [Authorize(Roles = "user")]
        [HttpGet("GetTeacher")]
        public async Task<IActionResult> GetTeacher()
        {
            var Id = int.Parse(HttpContext.User.Claims.First(claim => claim.Type == "PersonId").Value);
            var response = await _mediator.Send(new GetTeacherByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("Add")]
        public async Task<IActionResult> AddTeacher(AddTeacherCommand addTeacher)
        {
            var response = await _mediator.Send(addTeacher);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("AddByExistPerson")]
        public async Task<IActionResult> AddTeacherByExistPerson(AddTeacherByPersonCommand addTeacher)
        {
            var response = await _mediator.Send(addTeacher);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTeacher(UpdateTeacherCommand updateTeacher)
        {
            var response = await _mediator.Send(updateTeacher);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion
    }
}
