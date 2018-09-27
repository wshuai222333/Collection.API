using Collection.Api.DTO;
using Collection.Api.DTO.Agent;
using Collection.Api.Service.Agents;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Collection.Api.Controllers.Agent {
    [ApiController]
    [Produces("application/json")]
    [Route("api/Agent")]
    [EnableCors("AllowSameDomain")]
    public class UserController : BaseController {
        public AgentLoginService agentLoginService { get; set; }

        public AgentModifyPwdService agentModifyPwdService { get; set; }
        public AddAgentService addAgentService { get; set; }

        public AgentListService agentListService { get; set; }

        public AgentModifyStateService agentModifyStateService { get; set; }

        [Route("AgentLogin"), HttpPost]
        public async Task<ResponseMessageModel> UserLogin(RequestAgentLogin model) {
            return await Task.Run(() => agentLoginService.Execute(model));
        }


        [Route("AgentModifyPwd"), HttpPost]
        public async Task<ResponseMessageModel> AgentModifyPwd(RequestAgentModifyPassword model) {
            return await Task.Run(() => agentModifyPwdService.Execute(model));
        }

        [Route("AddAgent"), HttpPost]
        public async Task<ResponseMessageModel> AddAgent(RequestAddAgent model) {
            return await Task.Run(() => addAgentService.Execute(model));
        }
        [Route("AgentList"), HttpPost]
        public async Task<ResponseMessageModel> AgentList(RequestAgentList model) {
            return await Task.Run(() => agentListService.Execute(model));
        }
        [Route("AgentModifyState"), HttpPost]
        public async Task<ResponseMessageModel> AgentModifyState(RequestAgentModifyState model) {
            return await Task.Run(() => agentModifyStateService.Execute(model));
        }
    }
}
