using AVLacasa.Application.Models;
using Microsoft.AspNetCore.Http;

namespace AVLacasa.Application.Helpers
{
    public class SessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public long GetLoggedInUserId()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null)
            {
                return 0;
            }

            if (context.Items.TryGetValue("SessionData", out var value) && value is UsersLoginSessionData sessionData)
            {
                return sessionData.UserId ?? 0;
            }

            return 0;
        }
    }
}
