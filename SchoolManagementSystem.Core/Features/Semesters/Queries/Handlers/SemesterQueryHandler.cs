using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Semesters.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Semesters.Queries.Handlers
{
    public class SemesterQueryHandler : ResponseHandler, IRequestHandler<GetSemestersListQuery, Response<List<GetSemesterResponse>>>
                                                      , IRequestHandler<GetSemesterByIdQuery, Response<GetSemesterResponse>>
    {
        #region Fields
        private readonly ISemesterService _semesterService;
        #endregion

        #region Constructors
        public SemesterQueryHandler(ISemesterService semesterService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)

        {
            _semesterService = semesterService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<List<GetSemesterResponse>>> Handle(GetSemestersListQuery request, CancellationToken cancellationToken)
        {
            return Success(await _semesterService.GetSemestersListAsync());
        }

        public async Task<Response<GetSemesterResponse>> Handle(GetSemesterByIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _semesterService.GetSemesterByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<GetSemesterResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }
        #endregion
    }
}
