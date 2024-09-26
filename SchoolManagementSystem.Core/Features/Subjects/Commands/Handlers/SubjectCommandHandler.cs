using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Subjects.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Subjects.Commands.Handlers
{
    public class SubjectCommandHandler : ResponseHandler, IRequestHandler<AddSubjectCommand, Response<IdResponse>>
                                                        , IRequestHandler<UpdateSubjectCommand, Response<string>>
    //, IRequestHandler<DeleteSubjectCommand, Response<string>>
    {
        #region Fields
        private readonly ISubjectService _subjectService;
        #endregion

        #region Constructors
        public SubjectCommandHandler(ISubjectService subjectService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _subjectService = subjectService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<IdResponse>> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
        {
            var Result = await _subjectService.CreateSubjectAsync(new Subject(request.SubjectName, request.ClassId));
            return Result != -1 ? Created<IdResponse>(new IdResponse { Id = Result }) : Failed<IdResponse>();
        }

        public async Task<Response<string>> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            var Result = await _subjectService.UpdateSubjectAsync(new Subject(request.Id, request.SubjectName!, request.ClassId == null ? 0 : (int)request.ClassId));
            return Result ? Updated<string>() : Failed<string>();
        }

        //public async Task<Response<string>> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        //{
        //    var Deleted = await _subjectService.DeleteByIdAsync(request.Id);
        //    if (Deleted == 0)
        //        return Failed<string>();

        //    return Deleted<string>();
        //}
        #endregion
    }
}
