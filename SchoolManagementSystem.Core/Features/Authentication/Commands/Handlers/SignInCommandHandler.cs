using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Authentication.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Helper;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Handlers
{
    public class SignInCommandHandler : ResponseHandler, IRequestHandler<SignInByUserNameCommand, Response<JwtAuthResult>>
                                                       , IRequestHandler<RefreshTokenCommand, Response<string>>
    {

        #region Fields
        private readonly IUserService _userService;
        private readonly IUserRefreshTokenService _userRefreshTokenService;
        #endregion

        #region Constructors
        public SignInCommandHandler(IUserService userService, IStringLocalizer<SharedResource> stringLocalizer, IUserRefreshTokenService userRefreshTokenService) : base(stringLocalizer)
        {
            _userService = userService;
            _userRefreshTokenService = userRefreshTokenService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<JwtAuthResult>> Handle(SignInByUserNameCommand request, CancellationToken cancellationToken)
        {
            if (await _userService.IsPasswordCorrectAsync(request.UserName, request.Password))
            {
                var user = _userService.GetUsersListQueryable()
                                    .Include(x => x.Roles)
                                    .Select(x => new User
                                    {
                                        Id = x.Id,
                                        UserName = x.UserName,
                                        PersonId = x.PersonId,
                                        Roles = x.Roles.Select(x => new Role
                                        {
                                            Id = x.Id,
                                            Name = x.Name
                                        }).ToList(),
                                    })
                                    .Where(x => x.UserName == request.UserName).First();
                return Success(await _userRefreshTokenService.GetJWTTokenWithRefresherAsync(user));
            }
            return Unauthenticated<JwtAuthResult>();
        }

        public async Task<Response<string>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var AccessToken = await _userRefreshTokenService.RefreshAccessTokenAsync(request.RefreshToken);
            if (AccessToken != null)
                return Success(AccessToken);
            return Unauthenticated<string>();
        }
        #endregion
    }
}
