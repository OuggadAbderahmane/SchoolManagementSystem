using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Schedules.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Schedules.Commands.Validations
{
    public class UpdatePartOfScheduleValidator : AbstractValidator<UpdatePartOfScheduleCommand>
    {
        #region Fields
        private readonly IPartOfScheduleService _partofscheduleService;
        private readonly ISectionService _sectionService;
        private readonly ISubjectTeacherService _subjectTeacherService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion

        #region Constructors
        public UpdatePartOfScheduleValidator(IPartOfScheduleService partofscheduleService, ISubjectTeacherService subjectteacherService, IStringLocalizer<SharedResource> stringLocalizer, ISectionService sectionService)
        {
            _partofscheduleService = partofscheduleService;
            _sectionService = sectionService;
            _subjectTeacherService = subjectteacherService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            bool isSubjectTeacherExist = false;
            RuleFor(x => x.Day)
            .MustAsync(async (Key, CancellationToken) => await Task.FromResult(Key > 0 && Key <= 5))
            .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.Session)
            .MustAsync(async (Key, CancellationToken) => await Task.FromResult(Key > 0 && Key <= 7))
            .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.SectionId)
            .MustAsync(async (Key, CancellationToken) => await _sectionService.IsIdExistAsync(Key))
            .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.SubjectTeacherId)
                .MustAsync(async (Key, CancellationToken) =>
                {
                    isSubjectTeacherExist = await _subjectTeacherService.IsIdExistAsync(Key);
                    return isSubjectTeacherExist;
                })
                .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.SubjectTeacherId)
                .MustAsync(async (modle, Key, CancellationToken) =>
                {
                    if (isSubjectTeacherExist == true)
                        return await _partofscheduleService.IsSubjectTeacherAvailable(Key, modle.Day, modle.Session);
                    return true;
                })
                .WithMessage(_stringLocalizer[SharedResourcesKey.TeacherNotAvailable]);

        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.SectionId)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotLessThanOrEqualsTo] + " 0");

            RuleFor(x => x.Day)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull]);
            RuleFor(x => x.Session)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull]);

            RuleFor(x => x.SubjectTeacherId)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotLessThanOrEqualsTo] + " 0");
        }
        #endregion
    }
}
