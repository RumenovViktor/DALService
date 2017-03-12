using LocalApplicationServices;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace DALService.Controllers
{
    public class DashboardController : BaseApiController
    {
        public readonly IDashboardManager dashboardInfoProvider;

        public DashboardController(IDashboardManager dashboardInfoProvider)
        {
            this.dashboardInfoProvider = dashboardInfoProvider;
        }

        [HttpGet]
        public HttpResponseMessage GetSuitiblePositions()
        {
            return ExecuteAction(() =>
            {
                var queryString = Request.GetQueryNameValuePairs();
                var sectorId = queryString.Where(x => x.Key == "sectorId").FirstOrDefault().Value;
                var countryId = queryString.Where(x => x.Key == "countryId").FirstOrDefault().Value;
                var userId = queryString.Where(x => x.Key == "userId").FirstOrDefault().Value;

                return dashboardInfoProvider.GetSuitiblePositions(sectorId, countryId, userId);
            });
        }
    }
}