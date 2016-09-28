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
        public RegistrationController(IDALServiceData data) : base(data) { }

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
            var handler = new ApplicationServiceHandler<IRegistrationApplicationServiceLocal>();
            handler.Handle(new RegistrationApplicationServiceLocal(new DALServiceData()), command);
        }
    }
}