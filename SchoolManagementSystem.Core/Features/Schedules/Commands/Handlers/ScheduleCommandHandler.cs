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
            var Result = await _PartOfScheduleService.CreatePartOfScheduleAsync(
                                                            new PartOfSchedule()
                                                            {
                                                                SectionId = request.SectionId,
                                                                Day = request.Day,
                                                                Session = request.Session,
                                                                SubjectTeacherId = request.SubjectTeacherId,
                                                            });
            return Result != -1 ? Created<string>() : Failed<string>();
        }

        public async Task<Response<string>> Handle(UpdatePartOfScheduleCommand request, CancellationToken cancellationToken)
        {
            var Result = await _PartOfScheduleService.UpdatePartOfScheduleAsync(
                                                            new PartOfSchedule()
                                                            {
                                                                SectionId = request.SectionId,
                                                                Day = request.Day,
                                                                Session = request.Session,
                                                                SubjectTeacherId = request.SubjectTeacherId
                                                            });
            return Result ? Updated<string>() : Failed<string>();
        }
        #endregion
    }
}
