using Collection.Api.DTO.Agent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.Service.Agents {
    public class AgentListService : ApiOriBase<RequestAgentList> {
        #region 注入服务

        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            this.Result.Data = agentRep.GetAgentListByPage(this.Parameter.pageindex, this.Parameter.pagesize);
        }
    }
}
