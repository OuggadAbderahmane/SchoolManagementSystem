using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.SubjectTeachers.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.SubjectTeachers.Commands.Handlers
{
    public class SubjectTeacherCommandHandler : ResponseHandler, IRequestHandler<AddSubjectTeacherCommand, Response<IdResponse>>
    //, IRequestHandler<AddSubjectTeacherByPersonCommand, Response<string>>
    //, IRequestHandler<UpdateSubjectTeacherCommand, Response<string>>
    {
        #region Fields
        private readonly ISubjectTeacherService _SubjectTeacherService;
        #endregion

        #region Constructors
        public SubjectTeacherCommandHandler(ISubjectTeacherService SubjectTeacherService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)

        {
            _SubjectTeacherService = SubjectTeacherService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<IdResponse>> Handle(AddSubjectTeacherCommand request, CancellationToken cancellationToken)
        {

            var Result = await _SubjectTeacherService.CreateSubjectTeacherAsync(new SubjectTeacher(request.SubjectId, request.TeacherId));
            return Result != -1 ? Created<IdResponse>(new IdResponse { Id = Result }) : Failed<IdResponse>();
        }
        #endregion
    }
}
