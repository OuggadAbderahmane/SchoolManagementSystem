using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.StudentsEvaluations.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.StudentsEvaluations.Commands.Handlers
{
    public class StudentEvaluationCommandHandler : ResponseHandler, IRequestHandler<AddStudentEvaluationCommand, Response<IdResponse>>
                                                                  , IRequestHandler<UpdateStudentEvaluationCommand, Response<string>>
                                                                  , IRequestHandler<DeleteStudentEvaluationCommand, Response<string>>
    {
        #region Fields
        private readonly IStudentEvaluationService _studentevaluationService;
        #endregion

        #region Constructors
        public StudentEvaluationCommandHandler(IStudentEvaluationService studentevaluationService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _studentevaluationService = studentevaluationService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<IdResponse>> Handle(AddStudentEvaluationCommand request, CancellationToken cancellationToken)
        {
            var Result = await _studentevaluationService.CreateStudentEvaluationAsync(
                                                            new StudentEvaluation()
                                                            {
                                                                StudentId = request.StudentId,
                                                                SubjectId = request.SubjectId,
                                                                SemesterId = request.SemesterId,
                                                                YearId = request.YearId,
                                                                ContinuousAssessment = request.ContinuousAssessment,
                                                                FirstTest = request.FirstTest,
                                                                SecondTest = request.SecondTest,
                                                                Exam = request.Exam,
                                                            });
            return Result != -1 ? Created<IdResponse>(new IdResponse { Id = Result }) : Failed<IdResponse>();
        }

        public async Task<Response<string>> Handle(UpdateStudentEvaluationCommand request, CancellationToken cancellationToken)
        {
            var Result = await _studentevaluationService.UpdateStudentEvaluationAsync(
                                                            new StudentEvaluation()
                                                            {
                                                                Id = request.Id,
                                                                ContinuousAssessment = request.ContinuousAssessment,
                                                                FirstTest = request.FirstTest,
                                                                SecondTest = request.SecondTest,
                                                                Exam = request.Exam
                                                            });
            return Result ? Updated<string>() : Failed<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentEvaluationCommand request, CancellationToken cancellationToken)
        {
            var Deleted = await _studentevaluationService.DeleteByIdAsync(request.Id);
            if (Deleted == 0)
                return Failed<string>();

            return Deleted<string>();
        }
        #endregion
    }
}
