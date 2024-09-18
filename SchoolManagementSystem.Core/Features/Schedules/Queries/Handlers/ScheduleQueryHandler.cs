using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Schedules.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.PartOfSchedules.Queries.Handlers
{
    public class ScheduleQueryHandler : ResponseHandler, IRequestHandler<GetScheduleByIdQuery, Response<List<GetPartsOfScheduleResponse>>>
                                                       , IRequestHandler<IsSessionAvailableQuery, Response<bool?>>
                                                       , IRequestHandler<IsTeacherAvailableQuery, Response<bool?>>
                                                       , IRequestHandler<IsSubjectTeacherAvailableQuery, Response<bool?>>
    {
        #region Fields
        private readonly IPartOfScheduleService _PartOfScheduleService;
        private readonly ISectionService _SectionService;
        private readonly ITeacherService _TeacherService;
        private readonly ISubjectTeacherService _SubjectTeacherService;
        #endregion

        #region Constructors
        public ScheduleQueryHandler(IPartOfScheduleService PartOfScheduleService, ISectionService classService, IStringLocalizer<SharedResource> stringLocalizer, ITeacherService teacherService, ISubjectTeacherService subjectTeacherService) : base(stringLocalizer)

        {
            _PartOfScheduleService = PartOfScheduleService;
            _SectionService = classService;
            _TeacherService = teacherService;
            _SubjectTeacherService = subjectTeacherService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<List<GetPartsOfScheduleResponse>>> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            if (!await _SectionService.IsIdExistAsync(request.Id))
            {
                return NotFound<List<GetPartsOfScheduleResponse>>(_stringLocalizer[SharedResourcesKey.NotFound]);
            }
            var Response = await _PartOfScheduleService.GetScheduleBySectionIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<List<GetPartsOfScheduleResponse>>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<bool?>> Handle(IsSessionAvailableQuery request, CancellationToken cancellationToken)
        {
            if (!(await _SectionService.IsIdExistAsync(request.SectionId)) || request.Day > 5 || request.Session > 7)
                return NotFound<bool?>(_stringLocalizer[SharedResourcesKey.NotFound]);
            return Success<bool?>(await _PartOfScheduleService.IsSessionAvailableAsync(request.SectionId, request.Day, request.Session));
        }

        public async Task<Response<bool?>> Handle(IsTeacherAvailableQuery request, CancellationToken cancellationToken)
        {
            if (!(await _TeacherService.IsIdExistAsync(request.TeacherId)))
                return NotFound<bool?>("TeacherId " + _stringLocalizer[SharedResourcesKey.NotFound]);
            if (request.Day > 5 || request.Session > 7)
                return Failed<bool?>(null!);
            return Success<bool?>(await _PartOfScheduleService.IsTeacherAvailable(request.TeacherId, request.Day, request.Session));
        }

        public async Task<Response<bool?>> Handle(IsSubjectTeacherAvailableQuery request, CancellationToken cancellationToken)
        {
            if (!(await _SubjectTeacherService.IsIdExistAsync(request.SubjectTeacherId)))
                return NotFound<bool?>("SubjectTeacherId " + _stringLocalizer[SharedResourcesKey.NotFound]);
            if (request.Day > 5 || request.Session > 7)
                return Failed<bool?>(null!);
            return Success<bool?>(await _PartOfScheduleService.IsSubjectTeacherAvailable(request.SubjectTeacherId, request.Day, request.Session));
        }
        #endregion
    }
}
