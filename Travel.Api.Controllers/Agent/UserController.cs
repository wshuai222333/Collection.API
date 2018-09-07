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

        [Route("AgentLogin"), HttpPost]
        public async Task<ResponseMessageModel> UserLogin(RequestAgentLogin model) {
            return await Task.Run(() => agentLoginService.Execute(model));
        }


        [Route("AgentModifyPwd"), HttpPost]
        public async Task<ResponseMessageModel> AgentModifyPwd(RequestAgentModifyPassword model) {
            return await Task.Run(() => agentModifyPwdService.Execute(model));
        }
    }
}
