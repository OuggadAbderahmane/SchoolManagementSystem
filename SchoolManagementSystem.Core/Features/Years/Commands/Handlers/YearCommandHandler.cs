using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Years.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Years.Commands.Handlers
{
    public class YearCommandHandler : ResponseHandler, IRequestHandler<AddYearCommand, Response<IdResponse>>
                                                        , IRequestHandler<UpdateYearCommand, Response<string>>
    //, IRequestHandler<DeleteYearCommand, Response<string>>
    {
        #region Fields
        private readonly IYearService _yearService;
        #endregion

        #region Constructors
        public YearCommandHandler(IYearService yearService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _yearService = yearService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<IdResponse>> Handle(AddYearCommand request, CancellationToken cancellationToken)
        {
            var Result = await _yearService.CreateYearAsync(
                                                            new Year()
                                                            {
                                                                Value = request.Value,
                                                                IsActive = request.IsActive
                                                            });
            return Result != -1 ? Created<IdResponse>(new IdResponse { Id = Result }) : Failed<IdResponse>();
        }

        public async Task<Response<string>> Handle(UpdateYearCommand request, CancellationToken cancellationToken)
        {
            var Result = await _yearService.UpdateYearAsync(
                                                            new Year()
                                                            {
                                                                Id = request.Id,
                                                                IsActive = request.IsActive
                                                            });
            return Result ? Updated<string>() : Failed<string>();
        }

        //public async Task<Response<string>> Handle(DeleteYearCommand request, CancellationToken cancellationToken)
        //{
        //    var Deleted = await _yearService.DeleteByIdAsync(request.Id);
        //    if (Deleted == 0)
        //        return Failed<string>();

        //    return Deleted<string>();
        //}
        #endregion
    }
}
