namespace Ebuy.Web.Common.Extensions
{
    using System.Security.Claims;

    public static class UserExtensions
    {
        public static string GetId(this ClaimsPrincipal user) =>
            user.FindFirstValue(ClaimTypes.NameIdentifier);

        public static bool IsAdmin(this ClaimsPrincipal user) =>
            user.IsInRole(WebConstants.AdministratorRole);
    }
}