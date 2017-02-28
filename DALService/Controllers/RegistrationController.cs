namespace DALService.Controllers
{
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.ModelBinding;
    using System.Net;
    using Models;
    using LocalApplicationServices;
     
    public class RegistrationController : BaseApiController
    {
        private readonly IRegistrationApplicationServiceLocal registrationApplicationServiceLocal;

        public RegistrationController(IRegistrationApplicationServiceLocal registrationApplicationServiceLocal)
        {
            this.registrationApplicationServiceLocal = registrationApplicationServiceLocal;
        }

        [HttpPost]
        public HttpResponseMessage Register([ModelBinder(typeof(CommandModelBinder))] CommandEnvelope envelope)
        {
            return ExecuteAction(() => 
            {
                return registrationApplicationServiceLocal.Execute((UserRegistration)envelope.command);
            });
        }

        [HttpPost]
        public HttpResponseMessage CompanyRegister([ModelBinder(typeof(CommandModelBinder))] CommandEnvelope envelope)
        {
            return ExecuteAction(() =>
            {
                return registrationApplicationServiceLocal.Execute((CompanyRegistration)envelope.command);
            });
        }
    }
}