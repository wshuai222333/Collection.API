using Collection.Api.DTO.Agent;
using Collection.PetaPoco.Repositories.Collection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Collection.Api.Service.Agents {
    public class AgentTradeTotalService : ApiOriBase<RequestGetAgentTradeList> {
        #region 注入服务
        public AgentTradeRep agentTradeRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
          var list = agentTradeRep.GetAgentTradeLists(this.Parameter.AgentTradeId, 1, this.Parameter.TradeOrderId, this.Parameter.BeginTime, this.Parameter.EndTime);
            this.Result.Data = new {
                TotalAmount = list.Sum(i=>i.Amount),
                TotalProfits = list.Sum(i=>i.Profits)
            };
        }
    }
}
