using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Guardians.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Guardians.Commands.Validations
{
    public class AddGuardianValidator : AbstractValidator<AddGuardianCommand>
    {
        #region Fields
        private readonly IGuardianService _guardianService;
        private readonly IPersonService _personService;
        private readonly IJobService _jobService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        #endregion

        #region Constructors
        public AddGuardianValidator(IGuardianService guardianService, IPersonService personService, IJobService jobService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _guardianService = guardianService;
            _personService = personService;
            _jobService = jobService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }

        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.JobId)
                    .MustAsync(async (Key, CancellationToken) =>
                    {
                        return await _jobService.IsIdExistAsync(Key);
                    })
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);


            RuleFor(x => x.DateOfBirth)
                    .Must((Key, CancellationToken) => Key.Address?.Trim() != string.Empty)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty])
                    .Must((Key, CancellationToken) => Key.DateOfBirth != null ? Key.DateOfBirth >= DateTime.Now.AddYears(-100) && Key.DateOfBirth <= DateTime.Now : true)
                    .WithMessage(_stringLocalizer[SharedResourcesKey.DateMustBeValid]);

            RuleFor(x => x.Address)
                    .Must((Key, CancellationToken) => Key.Address?.Trim() != string.Empty)
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

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

            RuleFor(x => x.JobId)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotLessThanOrEqualsTo] + " 0");
        }
        #endregion
    }
}
