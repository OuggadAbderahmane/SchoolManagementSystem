using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Resources;

namespace SchoolManagementSystem.Core.Bases
{
    public class ResponseHandler
    {
        protected readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public ResponseHandler(IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public Response<T> Deleted<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _stringLocalizer[SharedResourcesKey.Deleted]
            };
        }
        public Response<T> Updated<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _stringLocalizer[SharedResourcesKey.Updated]
            };
        }
        public Response<T> Success<T>(T entity, object Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _stringLocalizer[SharedResourcesKey.Success],
                Meta = Meta
            };
        }
        public Response<T> Failed<T>(string message = null!)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = message == null ? _stringLocalizer[SharedResourcesKey.Failed] : message
            };
        }
        public Response<T> Unauthenticated<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = _stringLocalizer[SharedResourcesKey.Unauthorized]
            };
        }
        public Response<T> NotFound<T>(string message = null!)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? _stringLocalizer[SharedResourcesKey.NotFound] : message
            };
        }
        public Response<T> Created<T>(object Meta = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = _stringLocalizer[SharedResourcesKey.Created],
                Meta = Meta
            };
        }
    }
}
