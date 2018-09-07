using Collection.Api.DTO.Agent;
using Collection.PetaPoco.Repositories.Collection;

namespace Collection.Api.Service.Agents {
    public class AgentTradeService : ApiOriBase<RequestGetAgentTradeList> {
        #region 注入服务
        public AgentTradeRep agentTradeRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {

            this.Result.Data = agentTradeRep.GetAgentTradeList(this.Parameter.pageindex, this.Parameter.pagesize, this.Parameter.AgentTradeId, this.Parameter.State,this.Parameter.TradeOrderId,this.Parameter.BeginTime,this.Parameter.EndTime);
        }
    }
}
