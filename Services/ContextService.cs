using HMS.Abstraction;
using NuGet.Packaging.Signing;
using System.Reflection.Metadata.Ecma335;

namespace HMS.Services
{
    public class ContextService : IContextService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public ContextService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        // 
        public string GetUserName()
        {
            var username = _contextAccessor.HttpContext.User.Identity.Name;
            return string.IsNullOrEmpty(username) ? "Anonymous" : username;
        }

        public string GetUserId()
        {
            var userIdClaim = _contextAccessor.HttpContext?.User?.Claims
                .FirstOrDefault(c => c.Type == "UserId");
            return userIdClaim?.Value ?? string.Empty;
        }
       
        
        public bool IsUserLoggedIn()
        {
            return _contextAccessor?
                .HttpContext?
                .User?
                .Identity?
                .IsAuthenticated ?? true;
        }
    }
}
