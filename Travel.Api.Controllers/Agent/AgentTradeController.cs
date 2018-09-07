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
    public class AgentTradeController {
        public AgentTradeService agentTradeService { get; set; }
        public AgentTradeTotalService agentTradeTotalService { get; set; }
        public AgentTradeByAdminService agentTradeByAdminService { get; set; }

        [Route("GetAgentTradeList"), HttpPost]
        public async Task<ResponseMessageModel> GetAgentTradeList(RequestGetAgentTradeList model) {
            return await Task.Run(() => agentTradeService.Execute(model));
        }
        [Route("GetAgentTradeTotal"), HttpPost]
        public async Task<ResponseMessageModel> GetAgentTradeTotal(RequestGetAgentTradeList model) {
            return await Task.Run(() => agentTradeTotalService.Execute(model));
        }
        [Route("GetAgentTradeListByAdmin"), HttpPost]
        public async Task<ResponseMessageModel> GetAgentTradeListByAdmin(RequestGetAgentTradeListByAdmin model) {
            return await Task.Run(() => agentTradeByAdminService.Execute(model));
        }
    }
}
