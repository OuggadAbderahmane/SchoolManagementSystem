using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.SubjectTeachers.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.SubjectTeachers.Commands.Validations
{
    public class DeleteSubjectTeacherValidator : AbstractValidator<DeleteSubjectTeacherCommand>
    {
        #region Fields
        private readonly ISubjectTeacherService _subjectTeacherService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        #endregion

        #region Constructors
        public DeleteSubjectTeacherValidator(ISubjectTeacherService subjectTeacherService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _subjectTeacherService = subjectTeacherService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }

        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.Id)
            .MustAsync(async (model, Key, CancellationToken) => await _subjectTeacherService.IsIdExistAsync(Key))
            .WithMessage(_stringLocalizer[SharedResourcesKey.DoesNotExist]);

        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");
        }
        #endregion
    }
}
