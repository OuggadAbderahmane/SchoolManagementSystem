using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Teachers.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Core.Wrappers;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Handlers
{
    public class TeacherQueryHandler : ResponseHandler, IRequestHandler<GetTeacherByIdQuery, Response<GetAllTeacherInfoResponse>>
                                                      , IRequestHandler<GetTeachersPaginatedListQuery, Response<PaginatedResult<GetTeacherResponse>>>
    {
        #region Fields
        private readonly ITeacherService _teacherService;
        #endregion

        #region Constructors
        public TeacherQueryHandler(ITeacherService teacherService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)

        {
            _teacherService = teacherService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<GetAllTeacherInfoResponse>> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _teacherService.GetTeacherByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<GetAllTeacherInfoResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<PaginatedResult<GetTeacherResponse>>> Handle(GetTeachersPaginatedListQuery request, CancellationToken cancellationToken)
        {
            return Success(await _teacherService.GetTeachersListResponse().ToPaginatedListAsync(request.pageNumber, request.pageSize));
        }
        #endregion
    }
}
