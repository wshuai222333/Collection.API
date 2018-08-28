using Collection.Api.DTO.Middle;
using Collection.DDD.Logger;
using Collection.Entity.CollectionModel;
using Collection.PetaPoco.Repositories.Collection;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Collection.Api.Controllers.Trade {
    [Produces("application/json")]
    [Route("api/AgentTradeNotify")]
    [EnableCors("AllowSameDomain")]
    public class AgentTradeNotifyController : BaseController {
        #region 注入服务
        public AgentTradeRep agentTradeRep { get; set; }
         #endregion

        [Route("TradeNotify")]
        public ActionResult TradeNotify(string resp_code, string resp_desc, string platform_seq_id, string ord_id, string trans_amt, string mer_priv, string extension) {
            string strinfo = resp_code + "|" + resp_desc + "|" + ord_id + "|" + platform_seq_id + "|" + trans_amt + "|" + mer_priv;
            LoggerFactory.Instance.Logger_Info(strinfo, "TradeNotify");
            
            agentTradeRep.UpdateState(1, ord_id, platform_seq_id);
            var agentTrade = agentTradeRep.GetAgentTrade(new AgentTrade() { TradeOrderId = ord_id });

            var agentResponseModel = new AgentResponseModel() {
                Extension = extension,
                MerPriv = mer_priv,
                OrderId = ord_id,
                PlatformId = platform_seq_id,
                RespCode = resp_code,
                RespDesc = resp_desc,
                TransAmt = trans_amt,
                AgentId = agentTrade.AgentId.ToString()
            };
            string content = Newtonsoft.Json.JsonConvert.SerializeObject(agentResponseModel);
            string result = DDD.Utils.Http.HtttApiRequest.apiPost(agentTrade.BgRetUrl, content);
            LoggerFactory.Instance.Logger_Info(agentTrade+"|"+ord_id +"|"+ content + "|" + result, "TradeNotifyresult");
            return Content("ECHO_SEQ_ID=" + ord_id);
        }
    }
}
