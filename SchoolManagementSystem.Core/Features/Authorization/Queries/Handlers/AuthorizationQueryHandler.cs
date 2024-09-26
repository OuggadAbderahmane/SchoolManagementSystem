using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Authorization.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Core.Features.Authorization.Queries.Handlers
{
    public class AuthorizationQueryHandler : ResponseHandler, IRequestHandler<GetUserRolesQuery, Response<GetUserRolesResponse>>
                                                            , IRequestHandler<GetUserClaimsQuery, Response<GetUserClaimsResponse>>
    {

        #region Fields
        private readonly IAuthorizationService _roleService;
        #endregion

        #region Constructors
        public AuthorizationQueryHandler(IAuthorizationService roleService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _roleService = roleService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<GetUserRolesResponse>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            GetUserRolesResponse? result;
            if (int.TryParse(request.UserNameOrId.Trim(), out var userId))
                result = await _roleService.GetUserRolesResponseAsync(userId);
            else
                result = await _roleService.GetUserRolesResponseAsync(request.UserNameOrId);

            return (result == null) ? NotFound<GetUserRolesResponse>(_stringLocalizer[SharedResourcesKey.NotFound]) : Success(result);
        }

        public async Task<Response<GetUserClaimsResponse>> Handle(GetUserClaimsQuery request, CancellationToken cancellationToken)
        {
            GetUserClaimsResponse? result;
            if (int.TryParse(request.UserNameOrId.Trim(), out var userId))
                result = await _roleService.GetUserClaimsResponseAsync(userId);
            else
                result = await _roleService.GetUserClaimsResponseAsync(request.UserNameOrId);

            return (result == null) ? NotFound<GetUserClaimsResponse>(_stringLocalizer[SharedResourcesKey.NotFound]) : Success(result);
        }
        #endregion
    }

}
