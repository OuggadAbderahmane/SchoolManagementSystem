using MediatR;
using Microsoft.AspNetCore.Http;
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
                                                      , IRequestHandler<GetTeacherQuery, Response<GetAllTeacherInfoResponse>>
                                                      , IRequestHandler<GetTeachersPaginatedListQuery, Response<PaginatedResult<GetTeacherResponse>>>
    {
        #region Fields
        private readonly ITeacherService _teacherService;
        private readonly IHttpContextAccessor _contextAccessor;
        #endregion

        #region Constructors
        public TeacherQueryHandler(ITeacherService teacherService, IStringLocalizer<SharedResource> stringLocalizer, IHttpContextAccessor contextAccessor) : base(stringLocalizer)

        {
            _teacherService = teacherService;
            _contextAccessor = contextAccessor;
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

        public async Task<Response<GetAllTeacherInfoResponse>> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
        {
            var Id = int.Parse(_contextAccessor.HttpContext!.User.Claims.First(claim => claim.Type == "PersonId").Value);
            var Response = await _teacherService.GetTeacherByIdAsync(Id);
            return Response != null ? Success(Response) : NotFound<GetAllTeacherInfoResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }
        #endregion
    }
}
