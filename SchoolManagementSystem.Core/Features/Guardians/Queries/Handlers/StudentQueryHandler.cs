using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Guardians.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Core.Wrappers;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Guardians.Queries.Handlers
{
    public class GuardianQueryHandler : ResponseHandler, IRequestHandler<GetGuardianByIdQuery, Response<GetAllGuardianInfoResponse>>
                                                       , IRequestHandler<GetGuardiansPaginatedListQuery, Response<PaginatedResult<GetGuardianResponse>>>
    {
        #region Fields
        private readonly IGuardianService _guardianService;
        private readonly IJobService _jobService;
        #endregion

        #region Constructors
        public GuardianQueryHandler(IGuardianService guardianService, IJobService jobService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)

        {
            _guardianService = guardianService;
            _jobService = jobService;
        }
        #endregion

        #region Handle Functions

        public async Task<Response<GetAllGuardianInfoResponse>> Handle(GetGuardianByIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _guardianService.GetGuardianByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<GetAllGuardianInfoResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<PaginatedResult<GetGuardianResponse>>> Handle(GetGuardiansPaginatedListQuery request, CancellationToken cancellationToken)
        {
            return Success(await _guardianService.GetGuardiansListResponse().ToPaginatedListAsync(request.pageNumber, request.pageSize));
        }
        #endregion
    }
}
