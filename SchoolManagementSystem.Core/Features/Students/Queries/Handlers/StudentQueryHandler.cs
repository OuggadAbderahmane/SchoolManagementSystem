using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Core.Wrappers;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler, IRequestHandler<GetStudentByIdQuery, Response<GetAllStudentInfoResponse>>
                                                      , IRequestHandler<GetStudentQuery, Response<GetAllStudentInfoResponse>>
                                                      , IRequestHandler<GetStudentsPaginatedListQuery, Response<PaginatedResult<GetStudentResponse>>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IHttpContextAccessor _contextAccessor;
        #endregion

        #region Constructors
        public StudentQueryHandler(IStudentService studentService, IStringLocalizer<SharedResource> stringLocalizer, IHttpContextAccessor contextAccessor) : base(stringLocalizer)

        {
            _studentService = studentService;
            _contextAccessor = contextAccessor;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<GetAllStudentInfoResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _studentService.GetStudentByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<GetAllStudentInfoResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<GetAllStudentInfoResponse>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var Id = int.Parse(_contextAccessor.HttpContext!.User.Claims.First(claim => claim.Type == "PersonId").Value);
            var Response = await _studentService.GetStudentByIdAsync(Id);
            return Response != null ? Success(Response) : NotFound<GetAllStudentInfoResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<PaginatedResult<GetStudentResponse>>> Handle(GetStudentsPaginatedListQuery request, CancellationToken cancellationToken)
        {
            return Success(await _studentService.GetStudentsListResponse().ToPaginatedListAsync(request.pageNumber, request.pageSize));
        }
        #endregion
    }
}
