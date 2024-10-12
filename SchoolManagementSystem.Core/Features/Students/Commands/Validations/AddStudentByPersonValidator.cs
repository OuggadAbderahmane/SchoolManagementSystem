using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Validations
{
    public class AddStudentByPersonValidator : AbstractValidator<AddStudentByPersonCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IPersonService _personService;
        private readonly ISectionService _sectionService;
        private readonly IGuardianService _guardianService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        #endregion

        #region Constructors
        public AddStudentByPersonValidator(IStudentService studentService, IPersonService personService, ISectionService sectionService, IStringLocalizer<SharedResource> stringLocalizer, IGuardianService guardianService)
        {
            _studentService = studentService;
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
                    .MustAsync(async (Key, CancellationToken) => !await _studentService.IsIdExistAsync(Key))
                    .WithMessage(_stringLocalizer[SharedResourcesKey.StudentIdExist]);

            RuleFor(x => x.SectionId)
                    .MustAsync(async (Key, CancellationToken) =>
                    {
                        if (Key != null)
                            return await _sectionService.IsIdExistAsync((int)Key);
                        return true;
                    })
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.GuardianId)
                    .MustAsync(async (Key, CancellationToken) =>
                    {
                        if (Key != null)
                            return await _guardianService.IsIdExistAsync((int)Key);
                        return true;
                    })
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");

            RuleFor(x => x.IsActive)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull]);

            RuleFor(x => x.SectionId)
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");

            RuleFor(x => x.GuardianId)
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");
        }
        #endregion
    }
}
