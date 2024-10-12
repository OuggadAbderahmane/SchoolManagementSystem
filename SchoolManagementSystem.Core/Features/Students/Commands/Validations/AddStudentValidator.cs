using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Validations
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IPersonService _personService;
        private readonly ISectionService _sectionService;
        private readonly IGuardianService _guardianService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        #endregion

        #region Constructors
        public AddStudentValidator(IStudentService studentService, IPersonService personService, ISectionService sectionService, IStringLocalizer<SharedResource> stringLocalizer, IGuardianService guardianService)
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
            RuleFor(x => x.NationalCardNumber)
                    .MustAsync(async (Key, CancellationToken) => !await _personService.IsNationalCardNumberExistAsync(Key))
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.Exists]);


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

            RuleFor(x => x.Gender)
                    .Must((Key, CancellationToken) => _personService.GenderValidator(Key.Gender).Result)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);


            RuleFor(x => x.DateOfBirth)
                    .Must((Key, CancellationToken) => Key.DateOfBirth >= DateTime.Now.AddYears(-100) && Key.DateOfBirth <= DateTime.Now)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DateMustBeValid]);

            RuleFor(x => x.Address)
                    .Must((Key, CancellationToken) => Key.Address?.Trim() != string.Empty).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.NationalCardNumber)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(x => x.FirstName)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(x => x.LastName)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(x => x.Gender)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(x => x.IsActive)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(x => x.DateOfBirth)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(x => x.SectionId)
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");

            RuleFor(x => x.GuardianId)
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");
        }
        #endregion
    }
}
