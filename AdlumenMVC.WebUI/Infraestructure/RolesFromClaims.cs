using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace AdlumenMVC.WebUI.Infrastructure
{
    public class RolesFromClaims
    {
        public static IEnumerable<Claim> CreateRolesBasedOnClaims(ClaimsIdentity identity)
        {
            List<Claim> claims = new List<Claim>();


            if (identity.HasClaim(c => c.Type == "FTE" && c.Value == "1") )
            {
                claims.Add(new Claim(ClaimTypes.Role, "IncidentResolvers"));
             }
            return claims;
        }
    }
}