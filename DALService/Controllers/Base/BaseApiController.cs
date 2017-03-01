namespace DALService.Controllers
{
    using System.Web.Http;

    using Data.Unit_Of_Work;
    using System.Net.Http;
    using System;
    using System.Net;
    using Newtonsoft.Json;

    public class BaseApiController : ApiController
    {
        protected virtual HttpResponseMessage ExecuteAction<T>(Func<T> action)
        {
            try
            {
                var result = action();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
