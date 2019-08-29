using Gap.WepApi.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Gap.WepApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("fullname", typeof(FullnameConstraint));

            // Web API routes
            config.MapHttpAttributeRoutes(constraintResolver);
            Routing_Account(config);

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
        public static void Routing_Account(HttpConfiguration config)
        {
          
            config.Routes.MapHttpRoute(
               name: "User",
               routeTemplate: "api/account/login",
               defaults: new { controller = "user", action = "login" }
            );
        }
    }
}
