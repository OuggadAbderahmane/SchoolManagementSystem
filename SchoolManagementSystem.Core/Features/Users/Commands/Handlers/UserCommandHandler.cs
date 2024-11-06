using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Users.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Users.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
                                                     , IRequestHandler<UpdateUserCommand, Response<string>>
                                                     , IRequestHandler<DeleteUserCommand, Response<string>>
                                                     , IRequestHandler<ChangePasswordCommand, Response<string>>
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;
        #endregion

        #region Constructors
        public UserCommandHandler(IUserService userService, IStringLocalizer<SharedResource> stringLocalizer, IHttpContextAccessor contextAccessor) : base(stringLocalizer)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var success = await _userService.CreateAsync(
                                                            new User()
                                                            {
                                                                UserName = request.UserName,
                                                                PersonId = request.PersonId
                                                            },
                                                            request.Password,
                                                            request.Roles
                                                            );
            if (!success)
                return Failed<string>();

            return Created<string>();
        }

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var success = await _userService.UpdateUserAsync(
                                                            new User()
                                                            {
                                                                Id = request.Id,
                                                                UserName = request.UserName!,
                                                                PersonId = request.PersonId
                                                            });
            if (!success)
                return Failed<string>();

            return Updated<string>();
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var Deleted = await _userService.DeleteByIdAsync(request.Id);
            if (Deleted == 0)
                return Failed<string>();

            return Deleted<string>();
        }

        public async Task<Response<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            // Problem
            var userName = _contextAccessor.HttpContext!.User.Claims.First(claim => claim.Type == "userName").Value;
            var success = await _userService.UpdateUserPasswordAsync(userName, request.NewPassword, request.CurrentPassword);
            if (success == null)
                return Failed<string>("Incorrect Password");
            if (!(bool)success)
                return Failed<string>();

            return Updated<string>();
        }
        #endregion
    }
}
