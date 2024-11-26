using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Teachers.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Validations
{
    public class AddTeacherValidator : AbstractValidator<AddTeacherCommand>
    {
        #region Fields
        private readonly ITeacherService _teacherService;
        private readonly IPersonService _personService;
        private readonly ISectionService _sectionService;
        private readonly IGuardianService _guardianService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        #endregion

        #region Constructors
        public AddTeacherValidator(ITeacherService teacherService, IPersonService personService, ISectionService sectionService, IStringLocalizer<SharedResource> stringLocalizer, IGuardianService guardianService)
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

            RuleFor(x => x.Phone)
                    .Must((Key, CancellationToken) => Key.Phone?.Trim() != string.Empty)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty])
                    .Must((Key, CancellationToken) => Key.Phone != null ? _personService.NumberValidator(Key.Phone).Result : true)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.Email)
                    .Must((Key, CancellationToken) => Key.Email?.Trim() != string.Empty)
                    .NotEqual(string.Empty).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty])
                    .Must((Key, CancellationToken) => Key.Email != null ? _personService.EmailValidator(Key.Email).Result : true)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.DateOfBirth)
                    .Must((Key, CancellationToken) => Key.DateOfBirth == null || (Key.DateOfBirth >= DateTime.Now.AddYears(-100) && Key.DateOfBirth <= DateTime.Now))
                    .WithMessage(_stringLocalizer[SharedResourcesKey.DateMustBeValid]);

            RuleFor(x => x.Address)
                    .Must((Key, CancellationToken) => Key.Address?.Trim() != string.Empty).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);
        }

        public void ApplyValidationsRules()
        {

            RuleFor(x => x.FirstName)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(x => x.LastName)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(x => x.Gender)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull]);

            RuleFor(x => x.PermanentWork)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull]);
        }
        #endregion
    }
}
