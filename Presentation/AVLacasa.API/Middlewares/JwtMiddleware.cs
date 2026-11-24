using AVLacasa.Application.Interfaces;
using AVLacasa.Domain.Entities;
using Microsoft.Extensions.Options;
using AVLacasa.Application.Helpers;
using AVLacasa.Application.Models;

namespace AVLacasa.API.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IJwtUtilsRepository jwtUtils)
        {
            string token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last().SanitizeValue()!;
            UsersLoginSessionData? usersData = await jwtUtils.ValidateJwtToken(token);

            if (usersData != null)
            {
                // attach account to context on successful jwt validation
                context.Items["SessionData"] = usersData;
            }

            // removed manual SessionManager construction - use DI where needed elsewhere

            await _next(context);
        }
    }
}
