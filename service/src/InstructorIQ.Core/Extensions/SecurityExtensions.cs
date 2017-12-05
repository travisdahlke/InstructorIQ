﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using InstructorIQ.Core.Security;

namespace InstructorIQ.Core.Extensions
{
    public static class SecurityExtensions
    {
        public static bool IsGlobalAdministrator(this IPrincipal principal)
        {
            return principal is ClaimsPrincipal cp
                && cp.IsInRole(UserRoles.GlobalAdministrator);
        }

        public static bool IsOrganizationAdministrator(this IPrincipal principal)
        {
            return principal is ClaimsPrincipal cp
                && cp.IsInRole(UserRoles.OrganizationAdministrator);
        }


        public static string GetUserName(this IIdentity identity)
        {
            var ci = identity as ClaimsIdentity;
            return ci?.FindFirstValue(ClaimsIdentity.DefaultNameClaimType);
        }

        public static string GetUserId(this IIdentity identity)
        {
            var ci = identity as ClaimsIdentity;
            return ci?.FindFirstValue(TokenConstants.Claims.UserId);
        }

        public static string GetOrganizationId(this IIdentity identity)
        {
            var ci = identity as ClaimsIdentity;
            return ci?.FindFirstValue(TokenConstants.Claims.OrganizationId);
        }


        public static IEnumerable<string> GetRoles(this IIdentity identity)
        {
            return FindValues(identity as ClaimsIdentity, TokenConstants.Claims.Role);
        }

        public static IEnumerable<string> GetOrganizations(this IIdentity identity)
        {
            return FindValues(identity as ClaimsIdentity, TokenConstants.Claims.Organization);
        }


        public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
        {
            var claim = identity?.FindFirst(claimType);
            return claim?.Value;
        }

        public static IEnumerable<string> FindValues(this ClaimsIdentity identity, string claimType)
        {
            var claims = identity?
                .FindAll(claimType)
                .Select(c => c.Value);

            return claims;
        }
    }
}
