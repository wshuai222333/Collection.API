using Collection.DDD.Logger;
using Collection.PetaPoco.Repositories.Collection;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Collection.Api.Controllers.Trade {
    [Produces("application/json")]
    [Route("api/TradeNotify")]
    [EnableCors("AllowSameDomain")]
    public class TradeNotufyController:BaseController
    {
        #region 注入服务
        public TradeRep tradeRep { get; set; }
        #endregion
        [Route("TradeNotify")]
        public ActionResult TradeNotify(string resp_code, string resp_desc,string platform_seq_id,string ord_id,string trans_amt) {
            string strinfo = resp_code + "|" + resp_desc + "|" + ord_id + "|" + platform_seq_id + "|" + trans_amt;
            LoggerFactory.Instance.Logger_Info(strinfo, "TradeNotify");
            if (resp_code== "000" || resp_code == "100") {
                tradeRep.UpdateState(1, ord_id, platform_seq_id);
                return Content("ECHO_SEQ_ID=" + ord_id);
            } else {
                tradeRep.UpdateState(2, ord_id, platform_seq_id);
                return Content("ECHO_SEQ_ID=");
            }

            
        }

    }
}
