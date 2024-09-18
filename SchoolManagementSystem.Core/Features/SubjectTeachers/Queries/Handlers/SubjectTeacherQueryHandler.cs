using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.SubjectTeachers.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Core.Wrappers;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.SubjectTeachers.Queries.Handlers
{
    public class SubjectTeacherQueryHandler : ResponseHandler, IRequestHandler<GetSubjectTeacherByIdQuery, Response<GetSubjectTeacherResponse>>
                                                      , IRequestHandler<GetSubjectTeachersPaginatedListQuery, Response<PaginatedResult<GetSubjectTeacherResponse>>>
    {
        #region Fields
        private readonly ISubjectTeacherService _SubjectTeacherService;
        #endregion

        #region Constructors
        public SubjectTeacherQueryHandler(ISubjectTeacherService SubjectTeacherService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _SubjectTeacherService = SubjectTeacherService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<GetSubjectTeacherResponse>> Handle(GetSubjectTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _SubjectTeacherService.GetSubjectTeacherByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<GetSubjectTeacherResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<PaginatedResult<GetSubjectTeacherResponse>>> Handle(GetSubjectTeachersPaginatedListQuery request, CancellationToken cancellationToken)
        {
            return Success(await _SubjectTeacherService.GetSubjectTeachersListResponse().ToPaginatedListAsync(request.pageNumber, request.pageSize));
        }
        #endregion
    }
}
