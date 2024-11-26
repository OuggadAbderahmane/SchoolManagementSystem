using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Teachers.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Validations
{
    public class AddTeacherByPersonValidator : AbstractValidator<AddTeacherByPersonCommand>
    {
        #region Fields
        private readonly ITeacherService _teacherService;
        private readonly IPersonService _personService;
        private readonly ISectionService _sectionService;
        private readonly IGuardianService _guardianService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        #endregion

        #region Constructors
        public AddTeacherByPersonValidator(ITeacherService teacherService, IPersonService personService, ISectionService sectionService, IStringLocalizer<SharedResource> stringLocalizer, IGuardianService guardianService)
        {
            _teacherService = teacherService;
            _personService = personService;
            _sectionService = sectionService;
            _guardianService = guardianService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }

        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.Id)
                    .MustAsync(async (Key, CancellationToken) => await _personService.IsIdExistAsync(Key))
                    .WithMessage(_stringLocalizer[SharedResourcesKey.PersonIdNotExist]);

            RuleFor(x => x.Id)
                    .MustAsync(async (Key, CancellationToken) => !await _teacherService.IsIdExistAsync(Key))
                    .WithMessage(_stringLocalizer[SharedResourcesKey.TeacherIdExist]);

        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotLessThanOrEqualsTo] + " 0");

            RuleFor(x => x.PermanentWork)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull]);
        }
        #endregion
    }
}
