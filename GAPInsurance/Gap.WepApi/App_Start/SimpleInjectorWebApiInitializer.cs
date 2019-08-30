using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using Gap.DataAccess;
using Gap.Domain;
using Gap.DataAccess.Repositories;

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
            container.Register<IWebTokenUserRepository<GAPWebAPIUserToken>, WebUserTokenRepository>(Lifestyle.Transient);
            container.Register<ICoverTypePolicyRepository<GAPCoverTypePolicy>, CoverTypePolicyRepository>(Lifestyle.Transient);
            container.Register<ITypeRiksRepository<GAPTypeRisk>, TypeRiskRepository>(Lifestyle.Transient);
            container.Register<IPoliciesRepository<GAPPolicies>, PoliciesRepository>(Lifestyle.Transient);
            



        }
    }
}