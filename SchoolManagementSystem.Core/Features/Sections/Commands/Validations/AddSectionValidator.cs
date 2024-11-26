using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Sections.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Sections.Commands.Validations
{
    public class AddSectionValidator : AbstractValidator<AddSectionCommand>
    {
        #region Fields
        private readonly ISectionService _sectionService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        #endregion

        #region Constructors
        public AddSectionValidator(ISectionService sectionService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _sectionService = sectionService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }

        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.SectionName)
            .MustAsync(async (model, Key, CancellationToken) => !await _sectionService.IsExistAsync(Key, model.ClassId))
            .WithMessage(_stringLocalizer[SharedResourcesKey.ItExists]);

        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.SectionName)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEmpty().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEmpty]);

            RuleFor(x => x.ClassId)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotLessThanOrEqualsTo] + " 0");
        }
        #endregion
    }
}
