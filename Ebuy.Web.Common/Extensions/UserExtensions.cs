﻿namespace Ebuy.Web.Common.Extensions
{
    using System.Security.Claims;

    public static class UserExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}