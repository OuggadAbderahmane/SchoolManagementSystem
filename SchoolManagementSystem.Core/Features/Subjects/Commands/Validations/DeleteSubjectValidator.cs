using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Subjects.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Subjects.Commands.Validations
{
    public class DeleteSubjectValidator : AbstractValidator<DeleteSubjectCommand>
    {
        #region Fields
        private readonly ISubjectService _subjectService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        #endregion

        #region Constructors
        public DeleteSubjectValidator(ISubjectService subjectService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _subjectService = subjectService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustuomValidationsRules();
        }

        #endregion

        #region Actions
        public void ApplyCustuomValidationsRules()
        {
            RuleFor(x => x.Id)
            .MustAsync(async (model, Key, CancellationToken) => await _subjectService.IsIdExistAsync(Key))
            .WithMessage(_stringLocalizer[SharedResourcesKey.DoesNotExist]);

        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotEqualsTo] + " 0");
        }
        #endregion
    }
}
