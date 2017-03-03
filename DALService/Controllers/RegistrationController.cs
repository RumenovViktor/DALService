namespace DALService.Controllers
{
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.ModelBinding;
    using System.Net;
    using Models;
    using LocalApplicationServices;
    using ApplicationServices;

    public class RegistrationController : BaseApiController
    {
        protected readonly ICommonInfoManager commonInfoReadStore;
        private readonly IRegistrationApplicationServiceLocal registrationApplicationServiceLocal;

        public RegistrationController(IRegistrationApplicationServiceLocal registrationApplicationServiceLocal, ICommonInfoManager commonInfoReadStore)
        {
            this.commonInfoReadStore = commonInfoReadStore;
            this.registrationApplicationServiceLocal = registrationApplicationServiceLocal;
        }

        [HttpGet]
        public HttpResponseMessage GetActivityArea()
        {
            return ExecuteAction(() =>
            {
                return commonInfoReadStore.GetActivityArea();
            });
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