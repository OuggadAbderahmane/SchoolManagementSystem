using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.StudentsEvaluations.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.StudentsEvaluations.Queries.Handlers
{
    public class StudentEvaluationQueryHandler : ResponseHandler, IRequestHandler<GetStudentEvaluationByIdQuery, Response<GetStudentEvaluationResponse>>
                                                                , IRequestHandler<GetStudentEvaluationByInfoQuery, Response<GetStudentEvaluationResponse>>
                                                                , IRequestHandler<GetGradeReportQuery, Response<List<GetGradeReport>>>
                                                                , IRequestHandler<GetStudentGradeReportQuery, Response<List<GetGradeReport>>>
    {
        #region Fields
        private readonly IStudentEvaluationService _studentevaluationService;
        private readonly IHttpContextAccessor _contextAccessor;
        #endregion

        #region Constructors
        public StudentEvaluationQueryHandler(IStudentEvaluationService studentevaluationService, IStringLocalizer<SharedResource> stringLocalizer, IHttpContextAccessor contextAccessor) : base(stringLocalizer)
        {
            _studentevaluationService = studentevaluationService;
            _contextAccessor = contextAccessor;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<GetStudentEvaluationResponse>> Handle(GetStudentEvaluationByIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _studentevaluationService.GetStudentEvaluationByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<GetStudentEvaluationResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<GetStudentEvaluationResponse>> Handle(GetStudentEvaluationByInfoQuery request, CancellationToken cancellationToken)
        {
            var Response = await _studentevaluationService.GetStudentEvaluationByInfoAsync(request.StudentId, request.SubjectId, request.SemesterId, request.YearId);
            return Response != null ? Success(Response) : NotFound<GetStudentEvaluationResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<List<GetGradeReport>>> Handle(GetGradeReportQuery request, CancellationToken cancellationToken)
        {
            var Response = await _studentevaluationService.GetGradeReportAsync(request.StudentId, request.YearId, request.SemesterId);
            return Response != null ? Success(Response) : NotFound<List<GetGradeReport>>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<List<GetGradeReport>>> Handle(GetStudentGradeReportQuery request, CancellationToken cancellationToken)
        {
            var studentId = int.Parse(_contextAccessor.HttpContext!.User.Claims.First(claim => claim.Type == "PersonId").Value);
            var Response = await _studentevaluationService.GetGradeReportAsync(studentId, request.YearId, request.SemesterId);
            return Response != null ? Success(Response) : NotFound<List<GetGradeReport>>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }
        #endregion
    }
}