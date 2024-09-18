using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.SubjectTeachers.Commands.Models;
using SchoolManagementSystem.Core.Features.SubjectTeachers.Queries.Models;
using SchoolManagementSystem.Core.Resources;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class SubjectTeacherController(IMediator mediator, IStringLocalizer<SharedResource> stringLocalizer) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer = stringLocalizer;
        #endregion

        #region Handle Functions
        [HttpGet]
        public async Task<IActionResult> GetSubjectTeachersPaginatedList(int? pageNumber, int? pageSize)
        {
            return Ok(await _mediator.Send(new GetSubjectTeachersPaginatedListQuery(pageNumber, pageSize)));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSubjectTeacherById(int Id)
        {
            var response = await _mediator.Send(new GetSubjectTeacherByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubjectTeacher(AddSubjectTeacherCommand addSubjectTeacher)
        {
            var response = await _mediator.Send(addSubjectTeacher);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }
        #endregion
    }
}
