using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Schedules.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.PartOfSchedules.Queries.Handlers
{
    public class ScheduleQueryHandler : ResponseHandler, IRequestHandler<GetScheduleByIdQuery, Response<List<GetPartsOfStudentScheduleResponse>>>
                                                       , IRequestHandler<GetStudentScheduleQuery, Response<List<GetPartsOfStudentScheduleResponse>>>
                                                       , IRequestHandler<GetScheduleByTeacherIdQuery, Response<List<GetPartsOfTeacherScheduleResponse>>>
                                                       , IRequestHandler<GetTeacherScheduleQuery, Response<List<GetPartsOfTeacherScheduleResponse>>>
                                                       , IRequestHandler<IsSessionAvailableQuery, Response<bool?>>
                                                       , IRequestHandler<IsTeacherAvailableQuery, Response<bool?>>
                                                       , IRequestHandler<IsSubjectTeacherAvailableQuery, Response<bool?>>
    {
        #region Fields
        private readonly IPartOfScheduleService _PartOfScheduleService;
        private readonly IStudentService _StudentService;
        private readonly ISectionService _SectionService;
        private readonly ITeacherService _TeacherService;
        private readonly ISubjectTeacherService _SubjectTeacherService;
        private readonly IHttpContextAccessor _contextAccessor;
        #endregion

        #region Constructors
        public ScheduleQueryHandler(IPartOfScheduleService PartOfScheduleService, ISectionService sectionService, IStringLocalizer<SharedResource> stringLocalizer, ITeacherService teacherService, ISubjectTeacherService subjectTeacherService, IStudentService studentService, IHttpContextAccessor contextAccessor) : base(stringLocalizer)

        {
            _PartOfScheduleService = PartOfScheduleService;
            _StudentService = studentService;
            _SectionService = sectionService;
            _TeacherService = teacherService;
            _SubjectTeacherService = subjectTeacherService;
            _contextAccessor = contextAccessor;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<List<GetPartsOfStudentScheduleResponse>>> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            if (!await _SectionService.IsIdExistAsync(request.Id))
            {
                return NotFound<List<GetPartsOfStudentScheduleResponse>>(_stringLocalizer[SharedResourcesKey.NotFound]);
            }
            var Response = await _PartOfScheduleService.GetSectionScheduleByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<List<GetPartsOfStudentScheduleResponse>>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<List<GetPartsOfTeacherScheduleResponse>>> Handle(GetScheduleByTeacherIdQuery request, CancellationToken cancellationToken)
        {
            if (!await _TeacherService.IsIdExistAsync(request.TeacherId))
            {
                return NotFound<List<GetPartsOfTeacherScheduleResponse>>(_stringLocalizer[SharedResourcesKey.NotFound]);
            }
            var Response = await _PartOfScheduleService.GetTeacherScheduleByIdAsync(request.TeacherId);
            return Response != null ? Success(Response) : NotFound<List<GetPartsOfTeacherScheduleResponse>>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<List<GetPartsOfTeacherScheduleResponse>>> Handle(GetTeacherScheduleQuery request, CancellationToken cancellationToken)
        {

            var Id = int.Parse(_contextAccessor.HttpContext!.User.Claims.First(claim => claim.Type == "PersonId").Value);
            if (!await _TeacherService.IsIdExistAsync(Id))
            {
                return NotFound<List<GetPartsOfTeacherScheduleResponse>>(_stringLocalizer[SharedResourcesKey.NotFound]);
            }
            var Response = await _PartOfScheduleService.GetTeacherScheduleByIdAsync(Id);
            return Response != null ? Success(Response) : NotFound<List<GetPartsOfTeacherScheduleResponse>>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<List<GetPartsOfStudentScheduleResponse>>> Handle(GetStudentScheduleQuery request, CancellationToken cancellationToken)
        {
            var Id = int.Parse(_contextAccessor.HttpContext!.User.Claims.First(claim => claim.Type == "PersonId").Value);
            var Student = await _StudentService.GetStudentsListIQueryable().Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (Student == null || Student.SectionId == null)
            {
                return NotFound<List<GetPartsOfStudentScheduleResponse>>(_stringLocalizer[SharedResourcesKey.NotFound]);
            }
            var Response = await _PartOfScheduleService.GetSectionScheduleByIdAsync((int)Student.SectionId);
            return Response != null ? Success(Response) : NotFound<List<GetPartsOfStudentScheduleResponse>>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<bool?>> Handle(IsSessionAvailableQuery request, CancellationToken cancellationToken)
        {
            if (!await _SectionService.IsIdExistAsync(request.SectionId))
                return NotFound<bool?>(_stringLocalizer[SharedResourcesKey.NotFound]);
            return Success<bool?>(await _PartOfScheduleService.IsSessionAvailableAsync(request.SectionId, request.Day, request.Session));
        }

        public async Task<Response<bool?>> Handle(IsTeacherAvailableQuery request, CancellationToken cancellationToken)
        {
            if (!(await _TeacherService.IsIdExistAsync(request.TeacherId)))
                return NotFound<bool?>("TeacherId " + _stringLocalizer[SharedResourcesKey.NotFound]);
            return Success<bool?>(await _PartOfScheduleService.IsTeacherAvailable(request.TeacherId, request.Day, request.Session));
        }

        public async Task<Response<bool?>> Handle(IsSubjectTeacherAvailableQuery request, CancellationToken cancellationToken)
        {
            if (!(await _SubjectTeacherService.IsIdExistAsync(request.SubjectTeacherId)))
                return NotFound<bool?>("SubjectTeacherId " + _stringLocalizer[SharedResourcesKey.NotFound]);
            return Success<bool?>(await _PartOfScheduleService.IsSubjectTeacherAvailable(request.SubjectTeacherId, request.Day, request.Session));
        }
        #endregion
    }
}
