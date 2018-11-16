using System;
using System.Collections.Generic;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;

namespace NESReportsAPI.Providers
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        LoginBLL loginBLL = new LoginBLL();

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            Users userDetails = await loginBLL.ValidateUser(context.UserName, context.Password);

            if (userDetails != null)
            {
                if (!string.IsNullOrEmpty(userDetails.Username) && userDetails.ContentProviderId != 0)
                {
                    identity.AddClaim(new Claim("Username", userDetails.Username));
                    identity.AddClaim(new Claim("UserRole", userDetails.UserRole));
                    identity.AddClaim(new Claim("ContentProviderId", Convert.ToString(userDetails.ContentProviderId)));
                    identity.AddClaim(new Claim("AffiliateId", Convert.ToString(userDetails.AffiliateId)));

                    var authenticationProperties = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { "username", userDetails.Username }, { "userRole",userDetails.UserRole }
                });

                    var ticket = new AuthenticationTicket(identity, authenticationProperties);
                    context.Validated(ticket);
                }
                else
                {
                    context.SetError("invalid_grant", "Invalid credentials");
                    context.Rejected();
                }
            }
            else
            {
                context.SetError("invalid_grant", "Invalid credentials");
                context.Rejected();
            }

            return;
        }

        public override async Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            await Task.Run(() =>
            {
                foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
                {
                    context.AdditionalResponseParameters.Add(property.Key, property.Value);
                }
            });

            return;
        }
    }
}