using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Years.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Years.Commands.Validations
{
    public class UpdateYearValidator : AbstractValidator<UpdateYearCommand>
    {
        #region Fields
        private readonly IYearService _yearService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IClassService _classService;

        #endregion

        #region Constructors
        public UpdateYearValidator(IYearService yearService, IClassService classService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _yearService = yearService;
            _stringLocalizer = stringLocalizer;
            _classService = classService;
            ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.Id)
            .MustAsync(async (Key, CancellationToken) => await _yearService.IsIdExistAsync(Key))
            .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");

            RuleFor(x => x.IsActive)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull]);
        }
        #endregion
    }
}
