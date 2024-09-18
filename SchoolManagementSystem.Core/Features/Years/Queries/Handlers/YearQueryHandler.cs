using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Years.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Core.Wrappers;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Years.Queries.Handlers
{
    public class YearQueryHandler : ResponseHandler, IRequestHandler<GetYearByIdQuery, Response<GetYearResponse>>
                                                   , IRequestHandler<GetYearsPaginatedListQuery, Response<PaginatedResult<GetYearResponse>>>
    {
        #region Fields
        private readonly IYearService _yearService;
        #endregion

        #region Constructors
        public YearQueryHandler(IYearService yearService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)

        {
            _yearService = yearService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<GetYearResponse>> Handle(GetYearByIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _yearService.GetYearByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<GetYearResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<PaginatedResult<GetYearResponse>>> Handle(GetYearsPaginatedListQuery request, CancellationToken cancellationToken)
        {
            return Success(await _yearService.GetYearsListResponse().ToPaginatedListAsync(request.pageNumber, request.pageSize));
        }
        #endregion
    }
}
