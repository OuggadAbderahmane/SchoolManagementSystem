using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Authorization.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Authorization.Commands.Validation
{
    public class UpdateUserRolesValidator : AbstractValidator<UpdateUserRolesCommand>
    {
        #region Fields
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserService _userService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion

        #region Constructors
        public UpdateUserRolesValidator(IAuthorizationService authorizationService, IUserService userService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _authorizationService = authorizationService;
            _userService = userService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {

            RuleFor(x => x.UserNameOrId)
                .MustAsync(async (Key, CancellationToken) =>
                {
                    if (int.TryParse(Key.Trim(), out var userId))
                        return await _userService.IsIdExistAsync(userId);
                    else
                        return await _userService.IsUserNameExistAsync(Key);
                })
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleForEach(x => x.RolesName)
                .Must((Key) => Key != null)
                .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                .MustAsync(async (Key, CancellationToken) =>
                {
                    if (Key != null)
                        return await _authorizationService.RoleExistsAsync(Key);
                    return false;
                })
                .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);
        }
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.UserNameOrId)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleForEach(x => x.RolesName)
                    .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);
        }
        #endregion
    }
}
