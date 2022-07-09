using Application.Request_Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TeamController:BaseApiController
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public TeamController(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }
        [HttpPost("create")]
        public void CreateAsync(TeamRequest teamRequest)
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        }
    }
}
