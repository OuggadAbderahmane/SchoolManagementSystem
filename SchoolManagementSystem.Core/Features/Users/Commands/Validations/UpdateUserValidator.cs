using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Users.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Users.Commands.Validations
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IPersonService _personService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion

        #region Constructors
        public UpdateUserValidator(IUserService userService, IPersonService personService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _userService = userService;
            _personService = personService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }

        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.Id)
            .MustAsync(async (Key, CancellationToken) => await _userService.IsIdExistAsync(Key))
            .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.UserName)
                .MustAsync(async (model, Key, CancellationToken) =>
                                                            {
                                                                if (Key != null)
                                                                    return !await _userService.IsUserNameExistAsync(Key, model.Id);
                                                                return true;

                                                            })
                .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.Exists]);

            RuleFor(x => x.PersonId)
                .MustAsync(async (model, Key, CancellationToken) =>
                                                            {
                                                                if (Key != null)
                                                                    return !await _userService.IsPersonIdExistAsync((int)Key, model.Id);
                                                                return true;

                                                            })
                .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.Used]);

            RuleFor(x => x.PersonId)
                .MustAsync(async (Key, CancellationToken) =>
                                                            {
                                                                if (Key != null)
                                                                    return await _personService.IsIdExistAsync((int)Key);
                                                                return true;
                                                            })
                .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");

            RuleFor(x => x.PersonId)?
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");
        }
        #endregion
    }
}
