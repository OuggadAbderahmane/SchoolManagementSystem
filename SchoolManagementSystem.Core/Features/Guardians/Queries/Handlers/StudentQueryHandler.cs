using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Guardians.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Core.Wrappers;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Guardians.Queries.Handlers
{
    public class GuardianQueryHandler : ResponseHandler, IRequestHandler<GetGuardianByIdQuery, Response<GetAllGuardianInfoResponse>>
                                                       , IRequestHandler<GetGuardiansPaginatedListQuery, Response<PaginatedResult<GetGuardianResponse>>>
                                                       , IRequestHandler<GetGuardianQuery, Response<GetAllGuardianInfoResponse>>
    {
        #region Fields
        private readonly IGuardianService _guardianService;
        private readonly IJobService _jobService;
        private readonly IHttpContextAccessor _contextAccessor;
        #endregion

        #region Constructors
        public GuardianQueryHandler(IGuardianService guardianService, IJobService jobService, IStringLocalizer<SharedResource> stringLocalizer, IHttpContextAccessor contextAccessor) : base(stringLocalizer)

        {
            _guardianService = guardianService;
            _jobService = jobService;
            _contextAccessor = contextAccessor;
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
            return Success(await _guardianService.GetGuardiansListResponse(request.FirstName!, request.LastName!, request.Gender.HasValue ? request.Gender == enGender.MALE : null, request.JobID).ToPaginatedListAsync(request.pageNumber, request.pageSize));
        }

        public async Task<Response<GetAllGuardianInfoResponse>> Handle(GetGuardianQuery request, CancellationToken cancellationToken)
        {
            var Id = int.Parse(_contextAccessor.HttpContext!.User.Claims.First(claim => claim.Type == "PersonId").Value);
            var Response = await _guardianService.GetGuardianByIdAsync(Id);
            return Response != null ? Success(Response) : NotFound<GetAllGuardianInfoResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }
        #endregion
    }
}
