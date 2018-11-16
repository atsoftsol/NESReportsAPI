using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using NESReportsBLL;
using Microsoft.Owin.Security;
using NESReportsDTO;

namespace NESReportsAPI.Providers
{
    public class JWTAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        CommonHeaderBLL loginBLL = new CommonHeaderBLL();

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            AdminLogin userDetails = loginBLL.CheckLogin(context.UserName, context.Password);

            if (userDetails != null)
            {
                if (!string.IsNullOrEmpty(userDetails.userName) && userDetails.id != 0)
                {
                    identity.AddClaim(new Claim("Username", userDetails.userName));
                    identity.AddClaim(new Claim("UserId", Convert.ToString(userDetails.id)));

                    var authenticationProperties = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { "username", userDetails.userName }
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