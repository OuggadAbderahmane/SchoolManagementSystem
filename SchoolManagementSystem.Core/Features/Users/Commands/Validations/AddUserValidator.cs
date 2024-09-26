using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Users.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Users.Commands.Validations
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IPersonService _personService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion

        #region Constructors
        public AddUserValidator(IUserService UserService, IPersonService personService, IAuthorizationService authorizationService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _userService = UserService;
            _personService = personService;
            _authorizationService = authorizationService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }

        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.UserName)
                .MustAsync(async (model, Key, CancellationToken) => await _userService.IsUserNameMatchAsync(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKey.UserNameMatchError])
                .MustAsync(async (Key, CancellationToken) => !await _userService.IsUserNameExistAsync(Key))
                .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.Exists]);

            RuleFor(x => x.PersonId)
                .MustAsync(async (Key, CancellationToken) => !await _userService.IsPersonIdExistAsync(Key))
                .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.Used]);

            RuleFor(x => x.PersonId)
                .MustAsync(async (Key, CancellationToken) => await _personService.IsIdExistAsync(Key))
                .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.Roles)
                .MustAsync(async (Key, CancellationToken) =>
                {
                    if (Key != null)
                        foreach (var item in Key)
                        {
                            if (!await _authorizationService.RoleExistsAsync(item))
                                return false;
                        }
                    return true;
                })
                .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.UserName)
                .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(x => x.Password)
                .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty])
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#()\-+=$!%*?&])[A-Za-z\d@#()\-+=$!%*?&]{8,}$")
                .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.PasswordErrorMatch]);

            RuleFor(x => x.PersonId)
                .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");
        }
        #endregion
    }
}
