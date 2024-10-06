using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Users.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Users.Commands.Validations
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion

        #region Constructors
        public ChangePasswordValidator(IUserService UserService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _userService = UserService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }

        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.CurrentPassword)
            .Must((model, Key, CancellationToken) =>
            {
                return model.NewPassword != Key;
            })
            .WithMessage(_stringLocalizer[SharedResourcesKey.SamePassword]);
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.CurrentPassword)
                .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty])
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#()\-+=$!%*?&])[A-Za-z\d@#()\-+=$!%*?&]{8,}$")
                .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.PasswordErrorMatch]);
            RuleFor(x => x.NewPassword)
                .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty])
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#()\-+=$!%*?&])[A-Za-z\d@#()\-+=$!%*?&]{8,}$")
                .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.PasswordErrorMatch]);
        }
        #endregion
    }
}
