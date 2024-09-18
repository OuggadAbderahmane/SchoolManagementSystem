using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Years.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Years.Commands.Validations
{
    public class AddYearValidator : AbstractValidator<AddYearCommand>
    {
        #region Fields
        private readonly IYearService _yearService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        #endregion

        #region Constructors
        public AddYearValidator(IYearService yearService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _yearService = yearService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }

        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.Value)
            .MustAsync(async (model, Key, CancellationToken) => !await _yearService.IsExistAsync(Key))
            .WithMessage(_stringLocalizer[SharedResourcesKey.ItExists]);

        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Value)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(x => x.IsActive)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull]);
        }
        #endregion
    }
}
