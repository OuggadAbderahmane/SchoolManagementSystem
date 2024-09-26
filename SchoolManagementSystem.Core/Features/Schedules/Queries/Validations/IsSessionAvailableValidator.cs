using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Schedules.Queries.Models;
using SchoolManagementSystem.Core.Resources;

namespace SchoolManagementSystem.Core.Features.Schedules.Queries.Validations
{
    public class IsSessionAvailableValidator : AbstractValidator<IsSessionAvailableQuery>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion

        #region Constructors
        public IsSessionAvailableValidator(IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyCustuomValidationsRules();
        }

        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.SectionId)
            .Must((modle, Key, CancellationToken) => Key > 0)
            .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.Day)
            .Must((modle, Key, CancellationToken) => Key > 0 && Key <= 5)
            .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.Session)
            .Must((modle, Key, CancellationToken) => Key > 0 && Key <= 7)
            .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);
        }
        #endregion
    }
}
