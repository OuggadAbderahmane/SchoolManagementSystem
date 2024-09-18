using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.FinalExams.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.FinalExams.Queries.Handlers
{
    public class FinalExamQueryHandler : ResponseHandler, IRequestHandler<GetFinalExamByIdQuery, Response<GetFinalExamResponse>>
                                                        , IRequestHandler<GetFinalExamByInfoQuery, Response<GetFinalExamResponse>>
    {
        #region Fields
        private readonly IFinalExamService _finalexamService;
        #endregion

        #region Constructors
        public FinalExamQueryHandler(IFinalExamService finalexamService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _finalexamService = finalexamService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<GetFinalExamResponse>> Handle(GetFinalExamByIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _finalexamService.GetFinalExamByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<GetFinalExamResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<GetFinalExamResponse>> Handle(GetFinalExamByInfoQuery request, CancellationToken cancellationToken)
        {
            var Response = await _finalexamService.GetFinalExamByInfoAsync(request.StudentId, request.SubjectId, request.SemesterId, request.YearId);
            return Response != null ? Success(Response) : NotFound<GetFinalExamResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }
        #endregion
    }
}