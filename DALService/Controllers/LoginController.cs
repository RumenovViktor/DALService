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
        private readonly IValidations<CompanyLogin> companyValidations;
        private readonly IValidations<UserLogin> userValidations;

        public LoginController(IValidations<CompanyLogin> companyValidations, IValidations<UserLogin> userValidations)
        {
            this.companyValidations = companyValidations;
            this.userValidations = userValidations;
        }

        [HttpGet]
        public HttpResponseMessage UserLogin()
        {
            return ExecuteAction(() =>
            {
                var queryString = Request.GetQueryNameValuePairs();

                var email = queryString.ToArray()[0].Value;
                var password = queryString.ToArray()[1].Value;

                return userValidations.ValidateLogin(new UserLogin(email, password));
            });
        }

        [HttpGet]
        public HttpResponseMessage CompanyLogin()
        {
            var queryString = Request.GetQueryNameValuePairs();

            if (!queryString.Any())
                return Request.CreateResponse(HttpStatusCode.NoContent);

            var companyName = queryString.ToArray()[0].Value;
            var companyPassowrd = queryString.ToArray()[1].Value;

            var doesCompanyExist = companyValidations.ValidateLogin(new CompanyLogin(companyName, companyPassowrd));

            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(doesCompanyExist));
        }
    }
}