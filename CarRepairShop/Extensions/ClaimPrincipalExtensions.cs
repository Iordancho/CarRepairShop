using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.Extensions
{
    public static class ClaimPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        //public static bool IsAdmin(this ClaimsPrincipal user)
        //{
        //    return user.IsInRole("Admin");
        //}
    }
}
