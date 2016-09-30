using ApplicationServices;
using Autofac;
using Autofac.Integration.WebApi;
using Data.DataContext;
using Data.Unit_Of_Work;
using LocalApplicationServices;
using System.Reflection;
using System.Web.Http;

namespace DALService.App_Start
{
    public class AutofacContainer
    {
        private static IContainer Container { get; set; }

        public static IContainer Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterDependancies(builder);
            var config = GlobalConfiguration.Configuration;
            builder.RegisterWebApiFilterProvider(config);
            Container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);

            return Container;
        }

        private static void RegisterDependancies(ContainerBuilder builder)
        {
            builder.RegisterType<DALServiceDataContext>().As<IDALServiceDataContext>();
            builder.RegisterType<DALServiceData>().As<IDALServiceData>();
            builder.RegisterType<RegistrationApplicationServiceLocal>().As<IRegistrationApplicationServiceLocal>();
        }
    }
}
