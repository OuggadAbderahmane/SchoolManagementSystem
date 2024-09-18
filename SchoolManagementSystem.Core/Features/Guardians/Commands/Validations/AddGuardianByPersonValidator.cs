using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Guardians.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Guardians.Commands.Validations
{
    public class AddGuardianByPersonValidator : AbstractValidator<AddGuardianByPersonCommand>
    {
        #region Fields
        private readonly IGuardianService _guardianService;
        private readonly IPersonService _personService;
        private readonly IJobService _jobService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        #endregion

        #region Constructors
        public AddGuardianByPersonValidator(IGuardianService guardianService, IPersonService personService, IJobService jobService, IStringLocalizer<SharedResource> stringLocalizer)
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
            RuleFor(x => x.Id)
                    .MustAsync(async (Key, CancellationToken) => await _personService.IsIdExistAsync(Key))
                    .WithMessage(_stringLocalizer[SharedResourcesKey.PersonIdNotExist]);

            RuleFor(x => x.Id)
                    .MustAsync(async (Key, CancellationToken) => !await _guardianService.IsIdExistAsync(Key))
                    .WithMessage(_stringLocalizer[SharedResourcesKey.GuardianIdExist]);

            RuleFor(x => x.JobId)
                    .MustAsync(async (Key, CancellationToken) =>
                    {
                        return await _jobService.IsIdExistAsync(Key);
                    })
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");

            RuleFor(x => x.JobId)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");
        }
        #endregion
    }
}
