using Data.Unit_Of_Work;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using LocalApplicationServices.Validations;
using Models;

namespace DALService.Controllers
{
    public class LoginController : BaseApiController
    {
        private readonly ICompanyValidations companyValidations;

        public LoginController(ICompanyValidations companyValidations)
        {
            this.companyValidations = companyValidations;
        }

        [HttpGet]
        public HttpResponseMessage GetUser()
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format("{0}, is not valid."));
        }

        [HttpGet]
        public HttpResponseMessage CompanyLogin()
        {
            var queryString = Request.GetQueryNameValuePairs();

            if (!queryString.Any())
                return Request.CreateResponse(HttpStatusCode.NoContent);

            var companyName = queryString.ToArray()[0].Value;
            var companyPassowrd = queryString.ToArray()[1].Value;

            var doesCompanyExist = companyValidations.ValidateCompanyLogin(new CompanyLogin(companyName, companyPassowrd));

            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(doesCompanyExist));
        }
    }
}