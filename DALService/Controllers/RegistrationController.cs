namespace DALService.Controllers
{
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.ModelBinding;
    using Data.Unit_Of_Work;
    using System.Net;
    using Models;
    using LocalApplicationServices;

    public class RegistrationController : BaseApiController
    {
        private readonly IRegistrationApplicationServiceLocal registrationApplicationServiceLocal;

        public RegistrationController(IDALServiceData data, IRegistrationApplicationServiceLocal registrationApplicationServiceLocal) 
            : base(data)
        {
            this.registrationApplicationServiceLocal = registrationApplicationServiceLocal;
        }

        [HttpPost]
        public HttpResponseMessage Register([ModelBinder(typeof(CommandModelBinder))] CommandEnvelope envelope)
        {
            try
            {
                ExecuteCommand(envelope.command);

                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            catch (WebException e)
            {
                // TODO: Log error in logger.
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        private void ExecuteCommand(ICommand command)
        {
            registrationApplicationServiceLocal.Execute((UserRegistration)command);
        }
    }
}