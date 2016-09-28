using Autofac;
using Autofac.Integration.WebApi;
using Data.Unit_Of_Work;
using Data.Unit_Of_Work.Implementation;
using System.Reflection;
using System.Web.Http;

namespace DALService.App_Start
{
    public class AutofacContainer
    {
        public static ContainerBuilder Container { get; private set; }

        public static ContainerBuilder Initialize()
        {
            Container = new ContainerBuilder();
            Container.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterDependancies(Container);
            var config = GlobalConfiguration.Configuration;
            Container.RegisterWebApiFilterProvider(config);
            var container = Container.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return Container;
        }

        private static void RegisterDependancies(ContainerBuilder builder)
        {
            builder.RegisterType<DALServiceData>().As<IDALServiceData>();
        }
    }
}
