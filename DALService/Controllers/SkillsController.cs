using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Net;
using Models;
using LocalApplicationServices;
using Newtonsoft.Json;
using ApplicationServices;

namespace DALService.Controllers
{
    public class SkillsController : BaseApiController
    {
        private readonly ISkillsApplicationService skillsApplicationService;
        private readonly ISkillsManager skillsManager;

        public SkillsController(ISkillsApplicationService skillsApplicationService, ISkillsManager skillsManager)
        {
            this.skillsApplicationService = skillsApplicationService;
            this.skillsManager = skillsManager;
        }

        [HttpGet]
        public HttpResponseMessage GetMatchedSkills(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            var matchedSkills = skillsManager.GetMatchedSkills(name);
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(matchedSkills));
        }

        // TODO: Change name to AddUserSkill
        [HttpPost]
        public HttpResponseMessage CreateSkill([ModelBinder(typeof(CommandModelBinder))] CommandEnvelope envelope)
        {
            return ExecuteAction(() => 
            {
                return skillsApplicationService.Execute((SkillDtoWriteModel)envelope.command);
            });

        }

        [HttpPost]
        public HttpResponseMessage AddPositionSkill([ModelBinder(typeof(CommandModelBinder))] CommandEnvelope envelope)
        {
            return ExecuteAction(() =>
            {
                return skillsApplicationService.Execute((PositionRequiredSkill)envelope.command);
            });

        }
    }
}