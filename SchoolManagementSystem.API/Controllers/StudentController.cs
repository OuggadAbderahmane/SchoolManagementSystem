using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Core.Resources;

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

        [HttpGet]
        public async Task<IActionResult> GetStudentsPaginatedList(int? pageNumber, int? pageSize)
        {
            return Ok(await _mediator.Send(new GetStudentsPaginatedListQuery(pageNumber, pageSize)));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStudentById(int Id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddStudent(AddStudentCommand addStudent)
        {
            var response = await _mediator.Send(addStudent);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }
        [HttpPost("AddByExistPerson")]
        public async Task<IActionResult> AddStudentByExistPerson(AddStudentByPersonCommand addStudent)
        {
            var response = await _mediator.Send(addStudent);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateStudent(UpdateStudentCommand updateStudent)
        {
            var response = await _mediator.Send(updateStudent);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion
    }
}
