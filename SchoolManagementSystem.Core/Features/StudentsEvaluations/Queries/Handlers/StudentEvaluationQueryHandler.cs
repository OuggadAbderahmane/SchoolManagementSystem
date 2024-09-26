using MediatR;
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
    {
        #region Fields
        private readonly IStudentEvaluationService _studentevaluationService;
        #endregion

        #region Constructors
        public StudentEvaluationQueryHandler(IStudentEvaluationService studentevaluationService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _studentevaluationService = studentevaluationService;
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
        #endregion
    }
}