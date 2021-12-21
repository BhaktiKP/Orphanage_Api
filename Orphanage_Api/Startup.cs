using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Text;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Orphanage_Api.Startup))]

namespace Orphanage_Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            string securityKey = "qwerty0982412412412";

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "example@domain.in",
                    ValidAudience = "Users",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey))
                }
            });
        }
    }
}
