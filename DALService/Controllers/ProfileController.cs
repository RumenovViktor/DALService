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
                return Request.CreateResponse(HttpStatusCode.NoContent);

            var basicUserInfoModel = profileManager.GetUserProfileInfo(email);
            var serializedModel = JsonConvert.SerializeObject(basicUserInfoModel);

            return Request.CreateResponse(HttpStatusCode.OK, serializedModel);
        }

        // TODO: Move to CompanyProfileController
        [HttpGet]
        public HttpResponseMessage GetCompanyProfile()
        {
            var queryString = Request.GetQueryNameValuePairs();

            if (!queryString.Any())
                return Request.CreateResponse(HttpStatusCode.NoContent);

            var companyName = queryString.FirstOrDefault().Value;

            var companyProfle = profileManager.GetCompanyProfile(companyName);

            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(companyProfle));
        }

        [HttpPost]
        public HttpResponseMessage AddExperience([ModelBinder(typeof(CommandModelBinder))] CommandEnvelope envelope)
        {
            return ExecuteAction(() =>
            {
                return profileApplicationService.Execute((ExperienceViewModel)envelope.command);
            });
        }
    }
}
