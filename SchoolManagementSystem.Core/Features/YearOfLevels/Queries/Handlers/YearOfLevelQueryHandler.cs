using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.YearOfLevels.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.YearOfLevels.Queries.Handlers
{
    public class YearOfLevelQueryHandler : ResponseHandler, IRequestHandler<GetYearOfLevelsListQuery, Response<List<GetYearOfLevelResponse>>>
                                                      , IRequestHandler<GetYearOfLevelByIdQuery, Response<GetYearOfLevelResponse>>
    {
        #region Fields
        private readonly IYearOfLevelService _yearOfLevelService;
        #endregion

        #region Constructors
        public YearOfLevelQueryHandler(IYearOfLevelService yearOfLevelService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)

        {
            _yearOfLevelService = yearOfLevelService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<List<GetYearOfLevelResponse>>> Handle(GetYearOfLevelsListQuery request, CancellationToken cancellationToken)
        {
            return Success(await _yearOfLevelService.GetYearOfLevelsListAsync());
        }

        public async Task<Response<GetYearOfLevelResponse>> Handle(GetYearOfLevelByIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _yearOfLevelService.GetYearOfLevelByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<GetYearOfLevelResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }
        #endregion
    }
}
