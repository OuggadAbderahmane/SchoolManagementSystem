using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.FinalExams.Queries.Models;
using SchoolManagementSystem.Core.Resources;

namespace SchoolManagementSystem.Core.Features.FinalExams.Queries.Validations
{
    public class GetFinalExamByIdValidator : AbstractValidator<GetFinalExamByIdQuery>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion

        #region Constructors
        public GetFinalExamByIdValidator(IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            //ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }

        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .Must((model, Key, CancellationToken) => Key > 0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

        }
        public void ApplyValidationsRules()
        {

        }
        #endregion
    }
}
