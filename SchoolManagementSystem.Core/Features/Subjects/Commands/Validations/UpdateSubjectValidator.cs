using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Subjects.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Subjects.Commands.Validations
{
    public class UpdateSubjectValidator : AbstractValidator<UpdateSubjectCommand>
    {
        #region Fields
        private readonly ISubjectService _subjectService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IClassService _classService;

        #endregion

        #region Constructors
        public UpdateSubjectValidator(ISubjectService subjectService, IClassService classService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _subjectService = subjectService;
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
            .MustAsync(async (Key, CancellationToken) => await _subjectService.IsIdExistAsync(Key))
            .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.ClassId)
           .MustAsync(async (Key, CancellationToken) =>
                                                       {
                                                           if (Key != null)
                                                               return await _classService.IsIdExistAsync((int)Key);
                                                           return true;
                                                       })
           .WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.DoesNotExist]);

            RuleFor(x => x.SubjectName)
            .MustAsync(async (model, Key, CancellationToken) =>
                                                               {
                                                                   if (Key != null || model.ClassId != null)
                                                                       return !await _subjectService.IsExistAsync(Key, model.ClassId, model.Id);
                                                                   return true;
                                                               })
            .WithMessage(_stringLocalizer[SharedResourcesKey.ItExists]);

        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotNull])
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotLessThanOrEqualsTo] + " 0");

            RuleFor(x => x.ClassId)
                    .NotEqual(0).WithMessage("{PropertyName} " + _stringLocalizer[SharedResourcesKey.NotLessThanOrEqualsTo] + " 0");
        }
        #endregion
    }
}
