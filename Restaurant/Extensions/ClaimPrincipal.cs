using System.Security.Claims;


namespace Restaurant.Extensions
{
    public static class ClaimPrincipal
    {
 
    public static string? GetId(this ClaimsPrincipal user)
            {
                return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
        
    }
}
