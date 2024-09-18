using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.FinalExams.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.FinalExams.Commands.Validations
{
    public class AddFinalExamValidator : AbstractValidator<AddFinalExamCommand>
    {
        #region Fields
        private readonly IFinalExamService _finalexamService;
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly ISemesterService _semesterService;
        private readonly IYearService _yearService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        #endregion

        #region Constructors
        public AddFinalExamValidator(IFinalExamService finalexamService, IStudentService studentService, ISubjectService subjectService, IYearService yearService, ISemesterService semesterService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _finalexamService = finalexamService;
            _studentService = studentService;
            _subjectService = subjectService;
            _yearService = yearService;
            _semesterService = semesterService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }

        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            bool validations = true;
            RuleFor(x => x.StudentId)
                .MustAsync(async (model, Key, CancellationToken) =>
                {
                    if (await _studentService.IsIdExistAsync(Key))
                        return true;
                    validations = false;
                    return false;
                })
                .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.SubjectId)
                .MustAsync(async (model, Key, CancellationToken) =>
                {
                    if (await _subjectService.IsIdExistAsync(Key))
                        return true;
                    validations = false;
                    return false;
                })
                .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.SemesterId)
                .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                .MustAsync(async (Key, CancellationToken) =>
                {
                    if (await _semesterService.IsIdExistAsync(Key))
                        return true;
                    validations = false;
                    return false;
                }).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.YearId)
                .MustAsync(async (model, Key, CancellationToken) =>
                {
                    if (await _yearService.IsIdExistAsync(Key))
                        return true;
                    validations = false;
                    return false;
                })
                .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.StudentId)
                .MustAsync(async (modle, Key, CancellationToken) =>
                {
                    if (validations == true)
                        return !await _finalexamService.IsExistByInfoAsync(Key, modle.StudentId, modle.SemesterId, modle.YearId);
                    return true;
                })
                .WithMessage(_stringLocalizer[SharedResourcesKey.ItExists]);



        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.StudentId)
                .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                .Must((model, Key, CancellationToken) => Key > 0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.SubjectId)
                .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                .Must((model, Key, CancellationToken) => Key > 0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.YearId)
                .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                .Must((model, Key, CancellationToken) => Key > 0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);

            RuleFor(x => x.FinalExamNote)
                .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                .Must((model, Key, CancellationToken) => Key >= 0 && Key <= 20).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.MustBeValid]);
        }
        #endregion
    }
}
