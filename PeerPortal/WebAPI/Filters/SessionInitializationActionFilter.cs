using Application.Shared.Session;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebAPI.Filters
{
    public class SessionInitializationActionFilter : IAsyncActionFilter
    {
        private readonly Session _session;
        public SessionInitializationActionFilter(Session session)
        {
            _session = session;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)context.HttpContext.User.Identity!;
            _session.UserId = claimsIdentity?.Claims?.SingleOrDefault(c => c.Type == "uid")?.Value;
            _session.Username = claimsIdentity?.Claims?.SingleOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value;
            var resultContext = await next();
        }
    }
}
