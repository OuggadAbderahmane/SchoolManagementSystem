using Microsoft.AspNetCore.Http;

namespace SchoolManagementSystem.Infrastructure.HelperClass
{
    internal class helperClass : IHelperClass
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public helperClass(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetSchemeHost()
        {
            return _contextAccessor.HttpContext.Request.Scheme + "://" + _contextAccessor.HttpContext.Request.Host;
        }
    }
}
