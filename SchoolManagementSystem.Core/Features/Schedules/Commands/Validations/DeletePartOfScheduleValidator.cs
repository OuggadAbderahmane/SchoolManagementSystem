using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Schedules.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Schedules.Commands.Validations
{
    public class DeletePartOfScheduleValidator : AbstractValidator<DeletePartOfScheduleCommand>
    {
        #region Fields
        private readonly ISectionService _sectionService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion

        #region Constructors
        public DeletePartOfScheduleValidator(ISectionService sectionService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _sectionService = sectionService;
            ApplyCustuomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.SectionId)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0")
                    .MustAsync(async (Key, CancellationToken) => await _sectionService.IsIdExistAsync(Key))
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.Day)
                    .MustAsync(async (Key, CancellationToken) => await Task.FromResult(Key > 0 && Key <= 5))
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.Session)
                    .MustAsync(async (Key, CancellationToken) => await Task.FromResult(Key > 0 && Key <= 7))
                    .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

        }
        #endregion
    }
}
