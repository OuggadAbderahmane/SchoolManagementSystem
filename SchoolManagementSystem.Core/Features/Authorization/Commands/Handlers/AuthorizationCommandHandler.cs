using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Authorization.Commands.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Authorization.Commands.Handlers
{
    public class AuthorizationCommandHandler : ResponseHandler, IRequestHandler<UpdateUserRolesCommand, Response<string>>
    {
        #region Fields
        private readonly IAuthorizationService _roleService;
        #endregion

        #region Constructors
        public AuthorizationCommandHandler(IAuthorizationService roleService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _roleService = roleService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<string>> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            if (int.TryParse(request.UserNameOrId.Trim(), out var userId))
                await _roleService.UpdateUserRoles(new GetUserRolesResponse() { UserId = userId, UserName = null!, Roles = request.RolesName.Select(x => new Roles { Name = x }).ToList() });

            else
                await _roleService.UpdateUserRoles(new GetUserRolesResponse() { UserName = request.UserNameOrId, Roles = request.RolesName.Select(x => new Roles { Name = x }).ToList() });

            return Updated<string>();
        }
        #endregion
    }
}
