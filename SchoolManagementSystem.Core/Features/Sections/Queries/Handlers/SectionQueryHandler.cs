using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Sections.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Core.Wrappers;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Sections.Queries.Handlers
{
    public class SectionQueryHandler : ResponseHandler, IRequestHandler<GetSectionsListQuery, Response<List<GetSectionResponse>>>
                                                      , IRequestHandler<GetSectionByIdQuery, Response<GetSectionResponse>>
                                                      , IRequestHandler<GetSectionsPaginatedListQuery, Response<PaginatedResult<GetSectionResponse>>>
    {
        #region Fields
        private readonly ISectionService _sectionService;
        #endregion

        #region Constructors
        public SectionQueryHandler(ISectionService sectionService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)

        {
            _sectionService = sectionService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<List<GetSectionResponse>>> Handle(GetSectionsListQuery request, CancellationToken cancellationToken)
        {
            return Success(await _sectionService.GetSectionsListAsync());
        }

        public async Task<Response<GetSectionResponse>> Handle(GetSectionByIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _sectionService.GetSectionByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<GetSectionResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<PaginatedResult<GetSectionResponse>>> Handle(GetSectionsPaginatedListQuery request, CancellationToken cancellationToken)
        {
            return Success(await _sectionService.GetSectionsListResponse().ToPaginatedListAsync(request.pageNumber, request.pageSize));
        }
        #endregion
    }
}
