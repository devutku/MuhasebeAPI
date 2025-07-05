using System.Security.Claims;

namespace MuhasebeAPI.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                throw new UnauthorizedAccessException("User ID not found in token");
            
            return Guid.Parse(userIdClaim.Value);
        }

        public static string GetUserEmail(this ClaimsPrincipal user)
        {
            var emailClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            if (emailClaim == null)
                throw new UnauthorizedAccessException("User email not found in token");
            
            return emailClaim.Value;
        }

        public static bool HasUserId(this ClaimsPrincipal user)
        {
            return user.Claims.Any(c => c.Type == ClaimTypes.NameIdentifier);
        }
    }
} 