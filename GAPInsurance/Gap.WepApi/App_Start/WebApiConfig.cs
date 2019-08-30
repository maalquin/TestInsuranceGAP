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
               routeTemplate: "api/account/register",
               defaults: new { controller = "user", action = "register" }
            );

            config.Routes.MapHttpRoute(
             name: "Insurance",
             routeTemplate: "api/insurance/CoverTypePolicy",
             defaults: new { controller = "insurance", action = "CoverTypePolicy" });

            config.Routes.MapHttpRoute(
            name: "typeRisk",
            routeTemplate: "api/insurance/TypeOfRisk",
            defaults: new { controller = "insurance", action = "TypeOfRisk" });

            config.Routes.MapHttpRoute(
            name: "policies",
            routeTemplate: "api/insurance/GetPolicies",
            defaults: new { controller = "insurance", action = "GetPolicies" });

          
        }
    }
}
