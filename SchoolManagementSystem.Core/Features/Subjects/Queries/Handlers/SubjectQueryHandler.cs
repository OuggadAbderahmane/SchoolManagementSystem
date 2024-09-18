using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Subjects.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Core.Wrappers;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Subjects.Queries.Handlers
{
    public class SubjectQueryHandler : ResponseHandler, IRequestHandler<GetSubjectsListQuery, Response<List<GetSubjectResponse>>>
                                                      , IRequestHandler<GetSubjectByIdQuery, Response<GetSubjectResponse>>
                                                      , IRequestHandler<GetSubjectsPaginatedListQuery, Response<PaginatedResult<GetSubjectResponse>>>
    {
        #region Fields
        private readonly ISubjectService _subjectService;
        #endregion

        #region Constructors
        public SubjectQueryHandler(ISubjectService subjectService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)

        {
            _subjectService = subjectService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<List<GetSubjectResponse>>> Handle(GetSubjectsListQuery request, CancellationToken cancellationToken)
        {
            return Success(await _subjectService.GetSubjectsListAsync());
        }

        public async Task<Response<GetSubjectResponse>> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _subjectService.GetSubjectByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<GetSubjectResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<PaginatedResult<GetSubjectResponse>>> Handle(GetSubjectsPaginatedListQuery request, CancellationToken cancellationToken)
        {
            return Success(await _subjectService.GetSubjectsListResponse().ToPaginatedListAsync(request.pageNumber, request.pageSize));
        }
        #endregion
    }
}
