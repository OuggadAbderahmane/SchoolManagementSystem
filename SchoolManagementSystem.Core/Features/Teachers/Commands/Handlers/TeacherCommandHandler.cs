﻿using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Teachers.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Handlers
{
    public class TeacherCommandHandler : ResponseHandler, IRequestHandler<AddTeacherCommand, Response<IdResponse>>
                                                        , IRequestHandler<AddTeacherByPersonCommand, Response<string>>
                                                        , IRequestHandler<UpdateTeacherCommand, Response<string>>
    {
        #region Fields
        private readonly ITeacherService _teacherService;
        private readonly IPersonService _personService;
        private readonly IFileService _fileService;
        #endregion

        #region Constructors
        public TeacherCommandHandler(ITeacherService teacherService, IPersonService personService, IStringLocalizer<SharedResource> stringLocalizer, IFileService fileService) : base(stringLocalizer)

        {
            _teacherService = teacherService;
            _personService = personService;
            _fileService = fileService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<IdResponse>> Handle(AddTeacherCommand request, CancellationToken cancellationToken)
        {
            string? ImagePath = null;
            if (request.Image != null)
            {
                ImagePath = await _fileService.UploadImage("People", request.Image);
                if (ImagePath == null)
                    return Failed<IdResponse>(_stringLocalizer[SharedResourcesKey.ErrorImage]);
            }
            var Result = await _teacherService.CreateTeacherAsync(new Teacher
            {
                NationalCardNumber = request.NationalCardNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = _personService.GetGenderValue(request.Gender),
                Address = request.Address,
                PermanentWork = request.PermanentWork,
                Salary = request.Salary,
                Email = request.Email,
                Phone = request.Phone,
                ImagePath = ImagePath,
                DateOfBirth = request.DateOfBirth,
            });
            return Result != -1 ? Created<IdResponse>(new IdResponse { Id = Result }) : Failed<IdResponse>();
        }

        public async Task<Response<string>> Handle(AddTeacherByPersonCommand request, CancellationToken cancellationToken)
        {
            var Result = await _teacherService.CreateTeacherAsync(request.Id, request.Salary, request.PermanentWork);
            return Result ? Created<string>(_stringLocalizer[SharedResourcesKey.Created]) : Failed<string>();
        }

        public async Task<Response<string>> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            string? ImagePath = null;
            if (request.Image != null)
            {
                ImagePath = await _fileService.UploadImage("People", request.Image);
                if (ImagePath == null)
                    return Failed<string>(_stringLocalizer[SharedResourcesKey.ErrorImage]);
            }
            var Result = await _teacherService.UpdateTeacherAsync(request.Id,
                                                                     request.Salary,
                                                                     request.PermanentWork,
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
