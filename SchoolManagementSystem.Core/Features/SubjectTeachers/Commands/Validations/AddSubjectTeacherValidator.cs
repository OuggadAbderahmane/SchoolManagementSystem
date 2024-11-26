using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.SubjectTeachers.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.SubjectTeachers.Commands.Validations
{
    public class AddSubjectTeacherValidator : AbstractValidator<AddSubjectTeacherCommand>
    {
        #region Fields
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;
        private readonly ISubjectTeacherService _subjectteacherService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        #endregion

        #region Constructors
        public AddSubjectTeacherValidator(ISubjectTeacherService subjectTeacherService, ISubjectService subjectService, ITeacherService teacherService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _subjectteacherService = subjectTeacherService;
            _subjectService = subjectService;
            _teacherService = teacherService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }

        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.SubjectId)
            .MustAsync(async (Key, CancellationToken) => await _subjectService.IsIdExistAsync(Key))
            .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.TeacherId)
            .MustAsync(async (Key, CancellationToken) => await _teacherService.IsIdExistAsync(Key))
            .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.TeacherId)
            .MustAsync(async (modle, Key, CancellationToken) => !await _subjectteacherService.IsSubjectTeacherExistAsync(modle.SubjectId, Key))
            .WithMessage(_stringLocalizer[SharedResourcesKey.ItExists]);

        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.SubjectId)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotLessThanOrEqualsTo] + " 0");

            RuleFor(x => x.TeacherId)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotLessThanOrEqualsTo] + " 0");
        }
        #endregion
    }
}
