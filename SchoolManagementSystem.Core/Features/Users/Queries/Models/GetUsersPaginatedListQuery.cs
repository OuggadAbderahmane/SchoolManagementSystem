﻿using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Core.Features.Users.Queries.Models
{
    public class GetUsersPaginatedListQuery : IRequest<Response<PaginatedResult<GetUserResponse>>>
    {
        public int pageNumber;
        public int pageSize;

        public GetUsersPaginatedListQuery(int? pageNumber, int? pageSize = null)
        {
            this.pageNumber = pageNumber == null ? 1 : (int)pageNumber;
            this.pageSize = pageSize == null ? 10 : (int)pageSize;
        }
    }
}
