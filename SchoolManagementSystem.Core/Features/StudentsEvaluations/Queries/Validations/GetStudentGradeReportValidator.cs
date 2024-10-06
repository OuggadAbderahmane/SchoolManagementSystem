using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.StudentsEvaluations.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.StudentsEvaluations.Queries.Validations
{
    public class GetStudentGradeReportValidator : AbstractValidator<GetStudentGradeReportQuery>
    {
        #region Fields
        private readonly ISemesterService _semesterService;
        private readonly IYearService _yearService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        #endregion

        #region Constructors
        public GetStudentGradeReportValidator(ISemesterService semesterService, IYearService yearService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _semesterService = semesterService;
            _yearService = yearService;
            _stringLocalizer = stringLocalizer;
            //ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }

        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.SemesterId)
                .MustAsync(async (Key, CancellationToken) =>
                {
                    if (Key == 0)
                        return true;
                    return await _semesterService.IsIdExistAsync(Key);
                }).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);


            RuleFor(x => x.YearId)
                .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                .Must((model, Key, CancellationToken) => Key > 0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid])
                .MustAsync(async (model, Key, CancellationToken) => await _yearService.IsIdExistAsync(Key))
                .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);
        }
        public void ApplyValidationsRules()
        {

        }
        #endregion
    }
}
