using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Sections.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Sections.Commands.Handlers
{
    public class SectionCommandHandler : ResponseHandler, IRequestHandler<AddSectionCommand, Response<IdResponse>>
                                                        , IRequestHandler<UpdateSectionCommand, Response<string>>
    //, IRequestHandler<DeleteSectionCommand, Response<string>>
    {
        #region Fields
        private readonly ISectionService _sectionService;
        #endregion

        #region Constructors
        public SectionCommandHandler(ISectionService sectionService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _sectionService = sectionService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<IdResponse>> Handle(AddSectionCommand request, CancellationToken cancellationToken)
        {
            var Result = await _sectionService.CreateSectionAsync(
                                                            new Section()
                                                            {
                                                                Name = request.SectionName,
                                                                ClassId = request.ClassId
                                                            });
            return Result != -1 ? Created<IdResponse>(new IdResponse { Id = Result }) : Failed<IdResponse>();
        }

        public async Task<Response<string>> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
        {
            var Result = await _sectionService.UpdateSectionAsync(
                                                            new Section()
                                                            {
                                                                Id = request.Id,
                                                                Name = request.SectionName!,
                                                                ClassId = request.ClassId == null ? 0 : (int)request.ClassId
                                                            });
            return Result ? Updated<string>() : Failed<string>();
        }

        //public async Task<Response<string>> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
        //{
        //    var Deleted = await _sectionService.DeleteByIdAsync(request.Id);
        //    if (Deleted == 0)
        //        return Failed<string>();

        //    return Deleted<string>();
        //}
        #endregion
    }
}
