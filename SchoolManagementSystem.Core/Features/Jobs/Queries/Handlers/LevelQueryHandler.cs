using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Jobs.Queries.Models
{
    public class JobQueryHandler : ResponseHandler, IRequestHandler<GetJobsListQuery, Response<List<GetJobResponse>>>
                                                      , IRequestHandler<GetJobByIdQuery, Response<GetJobResponse>>
    {
        #region Fields
        private readonly IJobService _JobService;
        #endregion

        #region Constructors
        public JobQueryHandler(IJobService JobService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)

        {
            _JobService = JobService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<List<GetJobResponse>>> Handle(GetJobsListQuery request, CancellationToken cancellationToken)
        {
            return Success(await _JobService.GetJobsListAsync());
        }

        public async Task<Response<GetJobResponse>> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _JobService.GetJobByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<GetJobResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }
        #endregion
    }
}
