using Gap.WepApi.Constraints;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Cors;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

[assembly: OwinStartup(typeof(Gap.WepApi.Startup))]
namespace Gap.WepApi
{
    
        public class Startup
        {
        /// <summary>
        /// Enabled Cors in order to configurate Owin (asp.net Identity)
        /// </summary>
        /// <param name="app"></param>
            public void Configuration(IAppBuilder app)
            {
                app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
                ConfigureAuth(app);   
            }   
            public void ConfigureAuth(IAppBuilder app)
        {

            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationOAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                AllowInsecureHttp = true
            };
            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            
        }
        
    }

        
}
    
