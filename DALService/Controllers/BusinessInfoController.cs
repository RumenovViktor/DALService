namespace DALService.Controllers
{
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Net;

    using LocalApplicationServices.RegistrationLogin;
    using Newtonsoft.Json;
    
    public class BusinessInfoController : BaseApiController
    {
        private readonly IBusinessInfoProvider businessInfoProvider;

        public BusinessInfoController(IBusinessInfoProvider businessInfoProvider)
        {
            this.businessInfoProvider = businessInfoProvider;
        }

        [HttpGet]
        public HttpResponseMessage BasicUserInfo()
        {
            var email = string.Empty;
            var queryString = Request.GetQueryNameValuePairs();

            if (queryString.Count() != 0)
                email = queryString.FirstOrDefault().Value;
            else
                Request.CreateResponse(HttpStatusCode.NoContent);

            var basicUserInfoModel = businessInfoProvider.GetBasicUserInfo(email);
            var serializedModel = JsonConvert.SerializeObject(basicUserInfoModel);

            return Request.CreateResponse(HttpStatusCode.OK, serializedModel);
        }

        [HttpGet]
        public HttpResponseMessage SupportedSectors()
        {
            var supportedCompanies = businessInfoProvider.GetAllSupportedSectors();
            return Request.CreateResponse(HttpStatusCode.OK, supportedCompanies);
        }

        [HttpGet]
        public HttpResponseMessage SupportedCompanies(int sectorId)
        {
            var companiesInSector = businessInfoProvider.GetCompaniesForSector(sectorId);
            return Request.CreateResponse(HttpStatusCode.OK, companiesInSector);
        }
    }
}
