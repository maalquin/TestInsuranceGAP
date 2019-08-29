﻿using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using Gap.DataAccess;
using Gap.Domain;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Gap.WepApi.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace Gap.WepApi.App_Start
{
    public static class SimpleInjectorWebApiInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            container.Register<IRepository<GAPWebApiUser>, WebApiUserRepository>(Lifestyle.Transient);
        }
    }
}