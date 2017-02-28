using LocalApplicationServices;
using Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace DALService.Controllers
{
    public class FileUploadController : BaseApiController
    {
        private readonly IFileManagementApplicationService imageManagementApplicationService;

        public FileUploadController(IFileManagementApplicationService imageManagementApplicationService)
        {
            this.imageManagementApplicationService = imageManagementApplicationService;
        }

        [HttpPost]
        public HttpResponseMessage UploadImage([ModelBinder(typeof(CommandModelBinder))] CommandEnvelope envelope)
        {
            return ExecuteAction(() => 
            {
                return imageManagementApplicationService.Execute((File)envelope.command);
            });
        }
    }
}
