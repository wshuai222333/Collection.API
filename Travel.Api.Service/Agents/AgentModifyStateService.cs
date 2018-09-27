using Collection.Api.DTO.Agent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.Service.Agents {
    public class AgentModifyStateService : ApiOriBase<RequestAgentModifyState> {
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            this.Result.Data = agentRep.UpdateAgentState(this.Parameter.AgentModifyId,this.Parameter.State);
        }
    }
}
