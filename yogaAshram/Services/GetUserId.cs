using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace yogaAshram.Services
{
    public static class GetUserId
    {
        public static long GetCurrentUserId(HttpContext httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return -1;

            Claim claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (claim == null)
                return -1;

            long currentUserId;

            if (!long.TryParse(claim.Value, out currentUserId))
                return -1;

            return currentUserId;
        }
        
    }
}