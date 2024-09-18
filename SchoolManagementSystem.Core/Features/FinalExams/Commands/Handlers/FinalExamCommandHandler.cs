using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.FinalExams.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.FinalExams.Commands.Handlers
{
    public class FinalExamCommandHandler : ResponseHandler, IRequestHandler<AddFinalExamCommand, Response<IdResponse>>
                                                        , IRequestHandler<UpdateFinalExamCommand, Response<string>>
    //, IRequestHandler<DeleteFinalExamCommand, Response<string>>
    {
        #region Fields
        private readonly IFinalExamService _finalexamService;
        #endregion

        #region Constructors
        public FinalExamCommandHandler(IFinalExamService finalexamService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _finalexamService = finalexamService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<IdResponse>> Handle(AddFinalExamCommand request, CancellationToken cancellationToken)
        {
            var Result = await _finalexamService.CreateFinalExamAsync(
                                                            new FinalExam()
                                                            {
                                                                StudentId = request.StudentId,
                                                                SubjectId = request.SubjectId,
                                                                SemesterId = request.SemesterId,
                                                                YearId = request.YearId,
                                                                FinalExamNote = request.FinalExamNote,
                                                            });
            return Result != -1 ? Created<IdResponse>(new IdResponse { Id = Result }) : Failed<IdResponse>();
        }

        public async Task<Response<string>> Handle(UpdateFinalExamCommand request, CancellationToken cancellationToken)
        {
            var Result = await _finalexamService.UpdateFinalExamAsync(
                                                            new FinalExam()
                                                            {
                                                                Id = request.Id,
                                                                FinalExamNote = request.FinalExamNote
                                                            });
            return Result ? Updated<string>() : Failed<string>();
        }

        //public async Task<Response<string>> Handle(DeleteFinalExamCommand request, CancellationToken cancellationToken)
        //{
        //    var Deleted = await _finalexamService.DeleteByIdAsync(request.Id);
        //    if (Deleted == 0)
        //        return Failed<string>();

        //    return Deleted<string>();
        //}
        #endregion
    }
}
