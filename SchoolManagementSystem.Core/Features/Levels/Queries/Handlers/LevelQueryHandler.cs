using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Levels.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Levels.Queries.Handlers
{
    public class LevelQueryHandler : ResponseHandler, IRequestHandler<GetLevelsListQuery, Response<List<GetLevelResponse>>>
                                                      , IRequestHandler<GetLevelByIdQuery, Response<GetLevelResponse>>
    {
        #region Fields
        private readonly ILevelService _LevelService;
        #endregion

        #region Constructors
        public LevelQueryHandler(ILevelService LevelService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)

        {
            _LevelService = LevelService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<List<GetLevelResponse>>> Handle(GetLevelsListQuery request, CancellationToken cancellationToken)
        {
            return Success(await _LevelService.GetLevelsListAsync());
        }

        public async Task<Response<GetLevelResponse>> Handle(GetLevelByIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _LevelService.GetLevelByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<GetLevelResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }
        #endregion
    }
}
