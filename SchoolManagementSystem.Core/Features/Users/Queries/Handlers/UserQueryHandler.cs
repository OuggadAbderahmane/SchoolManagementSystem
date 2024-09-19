using MediatR;
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
                                                   , IRequestHandler<GetUserByIdQuery, Response<GetUserResponse>>
    //, IRequestHandler<GetUsersListQuery, Response<List<GetDepartmentsListResponse>>>
    {
        private readonly IUserService _userService;

        public UserQueryHandler(IUserService userService, IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            _userService = userService;
        }

        //public async Task<Response<List<GetDepartmentsListResponse>>> Handle(GetDepartmentsListQuery request, CancellationToken cancellationToken)
        //{
        //    return Success(await _departmentService.GetDepartmentsListResponseAsync());
        //}

        public async Task<Response<PaginatedResult<GetUserResponse>>> Handle(GetUsersPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<User, GetUserResponse>> exception = e => new GetUserResponse(e.Id, e.UserName, e.PersonId);
            return Success(await _userService.GetUsersListQueryable().Select(exception).ToPaginatedListAsync(request.pageNumber, request.pageSize));
        }

        public async Task<Response<GetUserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _userService.GetUserByIdAsync(request.Id);
            return Response != null ? Success(Response) : NotFound<GetUserResponse>(_stringLocalizer[SharedResourcesKey.NotFound]);
        }
    }
}
