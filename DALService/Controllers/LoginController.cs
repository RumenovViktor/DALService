using Data.Unit_Of_Work;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DALService.Controllers
{
    public class LoginController : BaseApiController
    {
        public LoginController(IDALServiceData data) : base(data) { }

        [HttpGet]
        public HttpResponseMessage GetUser()
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format("{0}, is not valid."));
        }
    }
}
