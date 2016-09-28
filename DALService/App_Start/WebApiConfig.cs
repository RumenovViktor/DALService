namespace DALService
{
    using Models;
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors();

            // Routing for urls that return data only for inner system/application
            config.Routes.MapHttpRoute(
                name: "InnerAppServiceUrl",
                routeTemplate: "controller/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.BindParameter(typeof(ICommand), new CommandModelBinder());
        }
    }
}
