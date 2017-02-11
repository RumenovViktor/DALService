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
            try
            {
                var executedCommand = ExecuteCommand(envelope.command);
                return Request.CreateResponse(HttpStatusCode.OK, executedCommand);
            }
            catch (WebException e)
            {
                // TODO: Log error in logger.
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage CompanyRegister([ModelBinder(typeof(CommandModelBinder))] CommandEnvelope envelope)
        {
            try
            {
                var executedCommand = registrationApplicationServiceLocal.Execute((CompanyRegistration)envelope.command);
                return Request.CreateResponse(HttpStatusCode.OK, executedCommand);
            }
            catch (WebException e)
            {
                // TODO: Log error in logger.
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        private ICommand ExecuteCommand(ICommand command)
        {
            return registrationApplicationServiceLocal.Execute((UserRegistration)command);
        }
    }
}