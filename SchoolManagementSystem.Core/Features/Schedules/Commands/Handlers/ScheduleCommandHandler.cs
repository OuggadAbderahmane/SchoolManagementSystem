using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Schedules.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Schedules.Commands.Handlers
{
    public class ScheduleCommandHandler : ResponseHandler, IRequestHandler<AddPartOfScheduleCommand, Response<string>>
                                                         , IRequestHandler<UpdatePartOfScheduleCommand, Response<string>>
                                                         , IRequestHandler<DeletePartOfScheduleCommand, Response<string>>
                                                         , IRequestHandler<DeleteScheduleBySectionIdCommand, Response<string>>
    {
        #region Fields
        private readonly IPartOfScheduleService _PartOfScheduleService;
        #endregion

        #region Constructors
        public ScheduleCommandHandler(IPartOfScheduleService PartOfScheduleService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _PartOfScheduleService = PartOfScheduleService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<string>> Handle(AddPartOfScheduleCommand request, CancellationToken cancellationToken)
        {
            var Result = await _PartOfScheduleService.CreatePartOfScheduleAsync(new PartOfSchedule(request.SectionId, request.Day, request.Session, request.SubjectTeacherId));
            return Result != -1 ? Created<string>() : Failed<string>();
        }

        public async Task<Response<string>> Handle(UpdatePartOfScheduleCommand request, CancellationToken cancellationToken)
        {
            var Result = await _PartOfScheduleService.UpdatePartOfScheduleAsync(new PartOfSchedule(request.SectionId, request.Day, request.Session, request.SubjectTeacherId));
            return Result ? Updated<string>() : Failed<string>();
        }

        public async Task<Response<string>> Handle(DeletePartOfScheduleCommand request, CancellationToken cancellationToken)
        {
            var Deleted = await _PartOfScheduleService.DeletePartOfScheduleAsync(request.SectionId, request.Day, request.Session);
            if (Deleted == 0)
                return Failed<string>();

            return Deleted<string>();
        }

        public async Task<Response<string>> Handle(DeleteScheduleBySectionIdCommand request, CancellationToken cancellationToken)
        {
            var Deleted = await _PartOfScheduleService.DeleteScheduleBySectionIdAsync(request.SectionId);
            if (Deleted == 0)
                return Failed<string>();

            return Deleted<string>();
        }
        #endregion
    }
}
