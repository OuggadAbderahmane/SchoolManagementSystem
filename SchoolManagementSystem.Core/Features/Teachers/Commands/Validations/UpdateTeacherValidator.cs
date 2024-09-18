using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Teachers.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Validations
{
    public class UpdateTeacherValidator : AbstractValidator<UpdateTeacherCommand>
    {
        #region Fields
        private readonly ITeacherService _teacherService;
        private readonly IPersonService _personService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion

        #region Constructors
        public UpdateTeacherValidator(ITeacherService teacherService, IPersonService personService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _teacherService = teacherService;
            _personService = personService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }

        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.Id)
            .MustAsync(async (Key, CancellationToken) => await _teacherService.IsIdExistAsync(Key))
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

            RuleFor(x => x.Salary)
                    .Must((Key, CancellationToken) =>
                    {
                        if (Key.Salary != null)
                            return Key.Salary >= 0;
                        return true;
                    })
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.Gender)
                    .Must((Key, CancellationToken) => Key.Gender?.Trim() != string.Empty)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty])
                    .Must((Key, CancellationToken) => Key.Gender != null ? _personService.GenderValidator(Key.Gender).Result : true)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.Address)
                    .Must((Key, CancellationToken) => Key.Address?.Trim() != string.Empty)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(x => x.Phone)
                    .Must((Key, CancellationToken) => Key.Phone?.Trim() != string.Empty)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty])
                    .Must((Key, CancellationToken) => Key.Phone != null ? _personService.PhoneValidator(Key.Phone).Result : true)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.Email)
                    .Must((Key, CancellationToken) => Key.Email?.Trim() != string.Empty)
                    .NotEqual(string.Empty).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty])
                    .Must((Key, CancellationToken) => Key.Email != null ? _personService.EmailValidator(Key.Email).Result : true)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.DateOfBirth)
                    .Must((Key, CancellationToken) => Key.DateOfBirth == null || (Key.DateOfBirth >= DateTime.Now.AddYears(-100) && Key.DateOfBirth <= DateTime.Now))
                    .WithMessage(_stringLocalizer[SharedResourcesKey.DateMustBeValid]);
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull] + " 0")
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");
        }
        #endregion
    }
}
