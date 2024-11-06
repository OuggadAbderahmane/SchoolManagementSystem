using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class StudentController(IMediator mediator, IStringLocalizer<SharedResource> stringLocalizer) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer = stringLocalizer;
        #endregion

        #region Handle Functions

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<Response<PaginatedResult<GetStudentResponse>>>> GetStudentsPaginatedList([FromQuery] GetStudentsPaginatedListQuery getStudentsPaginatedListQuery)
        {
            return Ok(await _mediator.Send(getStudentsPaginatedListQuery));
        }

        [Authorize(Roles = "admin")]
        [HttpGet("GetStudentById/{Id}")]
        public async Task<ActionResult<Response<GetAllStudentInfoResponse>>> GetStudentById(int Id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        /// <summary>
        /// Only Users have Student claim can use it
        /// </summary>
        [Authorize(policy: "StudentOnly")]
        [Authorize(Roles = "user")]
        [HttpGet("GetStudent")]
        public async Task<ActionResult<Response<GetAllStudentInfoResponse>>> GetStudent()
        {
            var response = await _mediator.Send(new GetStudentQuery());
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("Add")]
        public async Task<ActionResult<Response<IdResponse>>> AddStudent([FromForm] AddStudentCommand addStudent)
        {
            var response = await _mediator.Send(addStudent);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }

        /// <summary>
        /// If you have a person that already exists and want to make it Student
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPost("AddByExistPerson")]
        public async Task<ActionResult<Response<string>>> AddStudentByExistPerson(AddStudentByPersonCommand addStudent)
        {
            var response = await _mediator.Send(addStudent);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("Update")]
        public async Task<ActionResult<Response<string>>> UpdateStudent(UpdateStudentCommand updateStudent)
        {
            var response = await _mediator.Send(updateStudent);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("Delete/{Id}")]
        public async Task<ActionResult<Response<string>>> DeleteStudent(int Id)
        {
            var response = await _mediator.Send(new DeleteStudentCommand(Id));
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion
    }
}
