using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Subjects.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Subjects.Commands.Validations
{
    public class AddSubjectValidator : AbstractValidator<AddSubjectCommand>
    {
        #region Fields
        private readonly ISubjectService _subjectService;
        private readonly IClassService _classService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        #endregion

        #region Constructors
        public AddSubjectValidator(ISubjectService subjectService, IClassService classService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _subjectService = subjectService;
            _classService = classService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }

        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.SubjectName)
            .MustAsync(async (model, Key, CancellationToken) => !await _subjectService.IsExistAsync(Key, model.ClassId))
            .WithMessage(_stringLocalizer[SharedResourcesKey.ItExists]);

            RuleFor(x => x.ClassId)
            .MustAsync(async (Key, CancellationToken) => await _classService.IsIdExistAsync(Key))
            .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.SubjectName)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(x => x.ClassId)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");
        }
        #endregion
    }
}
