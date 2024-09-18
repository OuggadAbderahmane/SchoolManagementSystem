using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Validations
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IPersonService _personService;
        private readonly ISectionService _sectionService;
        private readonly IGuardianService _guardianService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        #endregion

        #region Constructors
        public UpdateStudentValidator(IStudentService studentService, IPersonService personService, ISectionService sectionService, IStringLocalizer<SharedResource> stringLocalizer, IGuardianService guardianService)
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
            .MustAsync(async (Key, CancellationToken) => await _studentService.IsIdExistAsync(Key))
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.NationalCardNumber)
                    .Must((Key, CancellationToken) => Key.NationalCardNumber?.Trim() != string.Empty)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty])
                    .MustAsync(async (model, Key, CancellationToken) => Key != null ? !await _personService.IsNationalCardNumberExistAsync(Key, model.Id) : true)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.Exists]);

            RuleFor(x => x.FirstName)
                    .Must((Key, CancellationToken) => Key.FirstName?.Trim() != string.Empty)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(x => x.LastName)
                    .Must((Key, CancellationToken) => Key.LastName?.Trim() != string.Empty)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

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
                    .Must((Key, CancellationToken) => Key.Gender?.Trim() != string.Empty)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty])
                    .Must((Key, CancellationToken) => Key.Gender != null ? _personService.GenderValidator(Key.Gender).Result : true)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.Address)
                    .Must((Key, CancellationToken) => Key.Address?.Trim() != string.Empty)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(x => x.DateOfBirth)
                    .Must((Key, CancellationToken) => Key.DateOfBirth == null || (Key.DateOfBirth >= DateTime.Now.AddYears(-100) && Key.DateOfBirth <= DateTime.Now))
                    .WithMessage(_stringLocalizer[SharedResourcesKey.DateMustBeValid]);
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull] + " 0")
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");

            RuleFor(x => x.SectionId)
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");

            RuleFor(x => x.GuardianId)
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");
        }
        #endregion
    }
}
