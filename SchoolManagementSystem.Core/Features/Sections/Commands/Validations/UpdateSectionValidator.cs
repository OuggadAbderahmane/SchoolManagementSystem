using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Sections.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Sections.Commands.Validations
{
    public class UpdateSectionValidator : AbstractValidator<UpdateSectionCommand>
    {
        #region Fields
        private readonly ISectionService _sectionService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IClassService _classService;

        #endregion

        #region Constructors
        public UpdateSectionValidator(ISectionService sectionService, IClassService classService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _sectionService = sectionService;
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
            .MustAsync(async (Key, CancellationToken) => await _sectionService.IsIdExistAsync(Key))
            .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.ClassId)
           .MustAsync(async (Key, CancellationToken) =>
                                                       {
                                                           if (Key != null)
                                                               return await _classService.IsIdExistAsync((int)Key);
                                                           return true;
                                                       })
           .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.SectionName)
            .MustAsync(async (model, Key, CancellationToken) =>
                                                               {
                                                                   if (Key != null || model.ClassId != null)
                                                                       return !await _sectionService.IsExistAsync(Key, model.ClassId, model.Id);
                                                                   return true;
                                                               })
            .WithMessage(_stringLocalizer[SharedResourcesKey.ItExists]);

        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");

            RuleFor(x => x.ClassId)
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");
        }
        #endregion
    }
}
