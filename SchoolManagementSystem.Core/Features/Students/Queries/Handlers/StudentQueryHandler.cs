using MediatR;
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
                                                      , IRequestHandler<GetStudentsPaginatedListQuery, Response<PaginatedResult<GetStudentResponse>>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        #endregion

        #region Constructors
        public StudentQueryHandler(IStudentService studentService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)

        {
            _studentService = studentService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<GetAllStudentInfoResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _studentService.GetStudentByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<GetAllStudentInfoResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<PaginatedResult<GetStudentResponse>>> Handle(GetStudentsPaginatedListQuery request, CancellationToken cancellationToken)
        {
            return Success(await _studentService.GetStudentsListResponse().ToPaginatedListAsync(request.pageNumber, request.pageSize));
        }
        #endregion
    }
}
