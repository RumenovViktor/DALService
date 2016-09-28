namespace DALService
{
    using App_Start;
    using System.Web;
    using System.Web.Http;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutofacContainer.Initialize();
        }

        protected void Application_Error()
        {
            // TODO: Handle Error...
        }
    }
}
