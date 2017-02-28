using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Models;
using ApplicationServices;

namespace DALService.Controllers
{
    public class CompanyProfileController : BaseApiController
    {
        private readonly ICompanyProfileApplicationService companyProfileCommandHandler;

        public CompanyProfileController(ICompanyProfileApplicationService companyProfileCommandHandler)
        {
            this.companyProfileCommandHandler = companyProfileCommandHandler;
        }

        [HttpPost]
        public HttpResponseMessage AddPosition([ModelBinder(typeof(CommandModelBinder))] CommandEnvelope envelope)
        {
            return ExecuteAction(() => 
            {
                return companyProfileCommandHandler.Execute((AddPosition)envelope.command);
            });
        }
    }
}