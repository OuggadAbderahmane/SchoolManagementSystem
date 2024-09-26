using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Authentication.Commands.Models;
using SchoolManagementSystem.Core.Resources;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Validation
{
    public class SignInByUserNameValidator : AbstractValidator<SignInByUserNameCommand>
    {

        #region Fields
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion

        #region Constructors
        public SignInByUserNameValidator(IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.UserName)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(x => x.Password)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);
        }
        #endregion
    }
}
