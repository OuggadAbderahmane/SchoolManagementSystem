using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Authentication.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Authentication.Commands.Handlers
{
    public class SignInCommandHandler : ResponseHandler, IRequestHandler<SignInByUserNameCommand, Response<string>>
                                                       , IRequestHandler<RefreshTokenCommand, Response<string>>
                                                       , IRequestHandler<LogoutCommand, Response<string>>
    {

        #region Fields
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserRefreshTokenService _userRefreshTokenService;
        #endregion

        #region Constructors
        public SignInCommandHandler(IUserService userService, IStringLocalizer<SharedResource> stringLocalizer, IUserRefreshTokenService userRefreshTokenService, IHttpContextAccessor contextAccessor) : base(stringLocalizer)
        {
            _userService = userService;
            _userRefreshTokenService = userRefreshTokenService;
            _contextAccessor = contextAccessor;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<string>> Handle(SignInByUserNameCommand request, CancellationToken cancellationToken)
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
                var TokenData = await _userRefreshTokenService.GetJWTTokenWithRefresherAsync(user);
                _userRefreshTokenService.SetTokenInsideCookie(TokenData);
                return Success(TokenData.AccessToken);
            }
            return Unauthenticated<string>();
        }

        public async Task<Response<string>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            if (_contextAccessor.HttpContext!.Request.Cookies.TryGetValue("refreshToken", out var refreshToken))
            {
                var AccessToken = await _userRefreshTokenService.RefreshAccessTokenAsync(refreshToken);
                if (AccessToken != null)
                    return Success(AccessToken);
            }
            return Unauthenticated<string>();
        }

        public Task<Response<string>> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            return _userRefreshTokenService.RemoveTokenFromCookies() ? Task.FromResult(Success("")) : Task.FromResult(Failed<string>());
        }
        #endregion
    }
}
