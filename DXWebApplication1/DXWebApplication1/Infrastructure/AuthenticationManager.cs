using DXWebApplication1.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Security;


namespace DXWebApplication1.Infrastructure
{
    public class AuthenticationManager
    {
        public static void SetAuthCookie(UserModel credentials)
        {
            bool isPersistent = credentials.rememberme;
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, credentials.username));
            claims.Add(new Claim(ClaimTypes.AuthenticationInstant, DateTime.Now.ToString()));
            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, AuthenticationTypes.Federation));
            principal = FederatedAuthentication.FederationConfiguration.IdentityConfiguration.ClaimsAuthenticationManager.Authenticate(HttpContext.Current.Request.RawUrl, principal);
            SessionSecurityToken sessionToken = FederatedAuthentication.SessionAuthenticationModule.CreateSessionSecurityToken(principal, "deneme mehmet", DateTime.UtcNow, DateTime.UtcNow.AddSeconds(1200),false);
            FederatedAuthentication.SessionAuthenticationModule.AuthenticateSessionSecurityToken(sessionToken, true);
        }

        public static void LogOut()
        {
            FederatedAuthentication.SessionAuthenticationModule.SignOut();
        }
    }
}