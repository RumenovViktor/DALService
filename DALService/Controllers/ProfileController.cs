using LocalApplicationServices.ProfileManagement.Contracts;
using Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace DALService.Controllers
{
    public class ProfileController : BaseApiController
    {
        private readonly IProfileApplicationService profileApplicationService;
        private readonly IProfileManager profileManager;

        public ProfileController(IProfileApplicationService profileApplicationService, IProfileManager profileManager)
        {
            this.profileApplicationService = profileApplicationService;
            this.profileManager = profileManager;
        }

        [HttpGet]
        public HttpResponseMessage GetUserProfile()
        {
            var email = string.Empty;
            var queryString = Request.GetQueryNameValuePairs();

            if (queryString.Count() != 0)
                email = queryString.FirstOrDefault().Value;
            else
                Request.CreateResponse(HttpStatusCode.NoContent);

            var basicUserInfoModel = profileManager.GetUserProfileInfo(email);
            var serializedModel = JsonConvert.SerializeObject(basicUserInfoModel);

            return Request.CreateResponse(HttpStatusCode.OK, serializedModel);
        }

        [HttpPost]
        public HttpResponseMessage AddExperience([ModelBinder(typeof(CommandModelBinder))] CommandEnvelope envelope)
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

        [HttpGet]
        public HttpResponseMessage GetMatchedSkills(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            var matchedSkills = profileManager.GetMatchedSkills(name);

            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(matchedSkills));
        }

        private ICommand ExecuteCommand(ICommand command)
        {
            return profileApplicationService.Execute((ExperienceViewModel)command);
        }
    }
}
