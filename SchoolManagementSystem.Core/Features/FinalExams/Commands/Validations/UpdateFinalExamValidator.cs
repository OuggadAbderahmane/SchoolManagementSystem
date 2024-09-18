using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.FinalExams.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.FinalExams.Commands.Validations
{
    public class UpdateFinalExamValidator : AbstractValidator<UpdateFinalExamCommand>
    {
        #region Fields
        private readonly IFinalExamService _finalexamService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IClassService _classService;

        #endregion

        #region Constructors
        public UpdateFinalExamValidator(IFinalExamService finalexamService, IClassService classService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _finalexamService = finalexamService;
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
            .MustAsync(async (Key, CancellationToken) => await _finalexamService.IsIdExistAsync(Key))
            .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");


            RuleFor(x => x.FinalExamNote)
                .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                .Must((model, Key, CancellationToken) => Key >= 0 && Key <= 20).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);
        }
        #endregion
    }
}
