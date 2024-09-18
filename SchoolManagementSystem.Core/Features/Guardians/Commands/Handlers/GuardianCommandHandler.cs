using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Guardians.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Guardians.Commands.Handlers
{
    public class GuardianCommandHandler : ResponseHandler, IRequestHandler<AddGuardianCommand, Response<IdResponse>>
                                                        , IRequestHandler<AddGuardianByPersonCommand, Response<string>>
                                                        , IRequestHandler<UpdateGuardianCommand, Response<string>>
    {
        #region Fields
        private readonly IGuardianService _guardianService;
        private readonly IPersonService _personService;
        private readonly IFileService _fileService;
        #endregion

        #region Constructors
        public GuardianCommandHandler(IGuardianService guardianService, IPersonService personService, IStringLocalizer<SharedResource> stringLocalizer, IFileService fileService) : base(stringLocalizer)

        {
            _guardianService = guardianService;
            _personService = personService;
            _fileService = fileService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<IdResponse>> Handle(AddGuardianCommand request, CancellationToken cancellationToken)
        {
            string? ImagePath = null;
            if (request.Image != null)
            {
                ImagePath = await _fileService.UploadImage("People", request.Image);
                if (ImagePath == null)
                    return Failed<IdResponse>(_stringLocalizer[SharedResourcesKey.ErrorImage]);
            }
            var Result = await _guardianService.CreateGuardianAsync(new Guardian
            {
                NationalCardNumber = request.NationalCardNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = _personService.GetGenderValue(request.Gender),
                Address = request.Address,
                JobID = request.JobId,
                Email = request.Email,
                Phone = request.Phone,
                ImagePath = ImagePath,
                DateOfBirth = request.DateOfBirth,
            });
            return Result != -1 ? Created<IdResponse>(new IdResponse { Id = Result }) : Failed<IdResponse>();
        }

        public async Task<Response<string>> Handle(AddGuardianByPersonCommand request, CancellationToken cancellationToken)
        {
            var Result = await _guardianService.CreateGuardianAsync(request.Id, request.JobId);
            return Result ? Created<string>(_stringLocalizer[SharedResourcesKey.Created]) : Failed<string>();
        }

        public async Task<Response<string>> Handle(UpdateGuardianCommand request, CancellationToken cancellationToken)
        {
            string? ImagePath = null;
            if (request.Image != null)
            {
                ImagePath = await _fileService.UploadImage("People", request.Image);
                if (ImagePath == null)
                    return Failed<string>(_stringLocalizer[SharedResourcesKey.ErrorImage]);
            }
            var Result = await _guardianService.UpdateGuardianAsync(request.Id,
                                                                     request.JobId,
                                                                     request.NationalCardNumber,
                                                                     request.FirstName,
                                                                     request.LastName,
                                                                     request.Gender != null ? _personService.GetGenderValue(request.Gender) : null,
                                                                     request.DateOfBirth,
                                                                     request.Address,
                                                                     ImagePath,
                                                                     request.Email,
                                                                     request.Phone);
            return Result ? Updated<string>() : Failed<string>();
        }
        #endregion
    }
}
