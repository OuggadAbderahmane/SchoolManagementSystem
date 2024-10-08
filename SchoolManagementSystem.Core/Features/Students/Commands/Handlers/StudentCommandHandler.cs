using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<IdResponse>>
                                                        , IRequestHandler<AddStudentByPersonCommand, Response<string>>
                                                        , IRequestHandler<UpdateStudentCommand, Response<string>>
                                                        , IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IPersonService _personService;
        private readonly IFileService _fileService;
        #endregion

        #region Constructors
        public StudentCommandHandler(IStudentService studentService, IPersonService personService, IStringLocalizer<SharedResource> stringLocalizer, IFileService fileService) : base(stringLocalizer)

        {
            _studentService = studentService;
            _personService = personService;
            _fileService = fileService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<IdResponse>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            string? ImagePath = null;
            if (request.ImagePath != null)
            {
                ImagePath = await _fileService.UploadImage("People", request.ImagePath);
                if (ImagePath == null)
                    return Failed<IdResponse>(_stringLocalizer[SharedResourcesKey.ErrorImage]);
            }
            var Result = await _studentService.CreateStudentAsync(new Student
            {
                NationalCardNumber = request.NationalCardNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = _personService.GetGenderValue(request.Gender),
                Address = request.Address,
                GuardianId = request.GuardianId,
                SectionId = request.SectionId,
                ImagePath = ImagePath,
                IsAvtive = request.IsAvtive,
                DateOfBirth = request.DateOfBirth,
            });
            return Result != -1 ? Created<IdResponse>(new IdResponse { Id = Result }) : Failed<IdResponse>();
        }

        public async Task<Response<string>> Handle(AddStudentByPersonCommand request, CancellationToken cancellationToken)
        {
            var Result = await _studentService.CreateStudentAsync(request.Id, request.SectionId, request.GuardianId, request.IsAvtive);
            return Result ? Created<string>() : Failed<string>();
        }

        public async Task<Response<string>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            string? ImagePath = null;
            if (request.ImagePath != null)
            {
                ImagePath = await _fileService.UploadImage("People", request.ImagePath);
                if (ImagePath == null)
                    return Failed<string>(_stringLocalizer[SharedResourcesKey.ErrorImage]);
            }
            var Result = await _studentService.UpdateStudentAsync(request.Id,
                                                                     request.SectionId,
                                                                     request.GuardianId,
                                                                     request.IsAvtive,
                                                                     request.NationalCardNumber,
                                                                     request.FirstName,
                                                                     request.LastName,
                                                                     request.Gender != null ? _personService.GetGenderValue(request.Gender) : null,
                                                                     request.DateOfBirth,
                                                                     request.Address,
                                                                     ImagePath);
            return Result ? Updated<string>() : Failed<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var Deleted = await _studentService.DeleteStudentAsync(request.Id);
            if (!Deleted)
                return Failed<string>(_stringLocalizer[SharedResourcesKey.DeleteError]);

            return Deleted<string>();
        }
        #endregion
    }
}
