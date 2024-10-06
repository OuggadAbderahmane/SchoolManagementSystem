using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Users.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Core.Wrappers;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Service.Abstracts;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Core.Features.Users.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler, IRequestHandler<GetUsersPaginatedListQuery, Response<PaginatedResult<GetUserResponse>>>
                                                   , IRequestHandler<GetUserByNameOrIdQuery, Response<GetUserResponse>>
                                                   , IRequestHandler<GetUserQuery, Response<GetUserResponse>>
    //, IRequestHandler<GetUsersListQuery, Response<List<GetDepartmentsListResponse>>>
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;
        #endregion

        #region Constructors
        public UserQueryHandler(IUserService userService, IStringLocalizer<SharedResource> stringLocalizer, IHttpContextAccessor contextAccessor) : base(stringLocalizer)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;
        }
        #endregion

        #region Handle Functions
        //public async Task<Response<List<GetDepartmentsListResponse>>> Handle(GetDepartmentsListQuery request, CancellationToken cancellationToken)
        //{
        //    return Success(await _departmentService.GetDepartmentsListResponseAsync());
        //}

        public async Task<Response<PaginatedResult<GetUserResponse>>> Handle(GetUsersPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<User, GetUserResponse>> exception = e => new GetUserResponse(e.Id, e.UserName, e.PersonId);
            return Success(await _userService.GetUsersListQueryable().Select(exception).ToPaginatedListAsync(request.pageNumber, request.pageSize));
        }

        public async Task<Response<GetUserResponse>> Handle(GetUserByNameOrIdQuery request, CancellationToken cancellationToken)
        {
            GetUserResponse Response;
            if (int.TryParse(request.UserNameOrId.Trim(), out var userId))
                Response = await _userService.GetUserByIdAsync(userId);
            else
                Response = await _userService.GetUserByNameAsync(request.UserNameOrId);
            return Response != null ? Success(Response) : NotFound<GetUserResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }

        public async Task<Response<GetUserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var Id = _contextAccessor.HttpContext!.User.Claims.First(claim => claim.Type == "UserName").Value;
            var Response = await _userService.GetUserByNameAsync(Id);
            return Response != null ? Success(Response) : NotFound<GetUserResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }
        #endregion
    }
}
