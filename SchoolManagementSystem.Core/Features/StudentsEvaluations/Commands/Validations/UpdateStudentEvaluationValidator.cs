using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.StudentsEvaluations.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.StudentsEvaluations.Commands.Validations
{
    public class UpdateStudentEvaluationValidator : AbstractValidator<UpdateStudentEvaluationCommand>
    {
        #region Fields
        private readonly IStudentEvaluationService _studentevaluationService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IClassService _classService;

        #endregion

        #region Constructors
        public UpdateStudentEvaluationValidator(IStudentEvaluationService studentevaluationService, IClassService classService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _studentevaluationService = studentevaluationService;
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
            .MustAsync(async (Key, CancellationToken) => await _studentevaluationService.IsIdExistAsync(Key))
            .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.ContinuousAssessment)?
                .Must((model, Key, CancellationToken) => Key >= 0 && Key <= 20).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.FirstTest)?
                .Must((model, Key, CancellationToken) => Key >= 0 && Key <= 20).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.SecondTest)?
                .Must((model, Key, CancellationToken) => Key >= 0 && Key <= 20).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.Exam)?
                .Must((model, Key, CancellationToken) => Key >= 0 && Key <= 20).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotLessThanOrEqualsTo] + " 0");
        }
        #endregion
    }
}
