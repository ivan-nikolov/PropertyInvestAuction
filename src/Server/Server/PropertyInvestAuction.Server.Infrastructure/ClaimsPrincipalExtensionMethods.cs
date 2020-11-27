﻿namespace PropertyInvestAuction.Server.Infrastructure
{
    using System.Linq;
    using System.Security.Claims;

    public static class ClaimsPrincipalExtensionMethods
    {
        public static string GetId(this ClaimsPrincipal user)
            => user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
    }
}
