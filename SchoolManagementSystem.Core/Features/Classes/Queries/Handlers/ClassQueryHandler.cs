using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Classes.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Classes.Queries.Handlers
{
    public class ClassQueryHandler : ResponseHandler, IRequestHandler<GetClassesListQuery, Response<List<GetClassResponse>>>
                                                      , IRequestHandler<GetClassByIdQuery, Response<GetClassResponse>>
    {
        #region Fields
        private readonly IClassService _ClassService;
        #endregion

        #region Constructors
        public ClassQueryHandler(IClassService ClassService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)

        {
            _ClassService = ClassService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<List<GetClassResponse>>> Handle(GetClassesListQuery request, CancellationToken cancellationToken)
        {
            return Success(await _ClassService.GetClassesListAsync(request.LevelId, request.YearOfLevelId));
        }

        public async Task<Response<GetClassResponse>> Handle(GetClassByIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _ClassService.GetClassByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<GetClassResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }
        #endregion
    }
}
