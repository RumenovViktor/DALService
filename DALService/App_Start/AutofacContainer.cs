namespace DALService.App_Start
{
    using System.Reflection;
    using System.Web.Http;

    using Autofac;
    using Autofac.Integration.WebApi;

    using Data.DataContext;
    using Data.Unit_Of_Work;
    using LocalApplicationServices;
    using LocalApplicationServices.RegistrationLogin;

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
            builder.RegisterType<BusinessInfoProvider>().As<IBusinessInfoProvider>();
            builder.RegisterType<ImagesManagementApplicationServiceLocal>()
                   .As<IFileManagementApplicationService>();
        }
    }
}
