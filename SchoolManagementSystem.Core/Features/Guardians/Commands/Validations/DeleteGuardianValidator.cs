using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Guardians.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Guardians.Commands.Validations
{
    public class DeleteGuardianValidator : AbstractValidator<DeleteGuardianCommand>
    {
        #region Fields
        private readonly IGuardianService _guardianService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion

        #region Constructors
        public DeleteGuardianValidator(IGuardianService guardianService, IStringLocalizer<SharedResource> stringLocalizer)
        {
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
            .MustAsync(async (model, Key, CancellationToken) => await _guardianService.IsIdExistAsync(Key))
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
