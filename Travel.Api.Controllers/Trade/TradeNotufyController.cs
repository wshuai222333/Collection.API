using Collection.DDD.Logger;
using Collection.Entity.CollectionModel;
using Collection.PetaPoco.Repositories.Collection;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Collection.Api.Controllers.Trade {
    [Produces("application/json")]
    [Route("api/TradeNotify")]
    [EnableCors("AllowSameDomain")]
    public class TradeNotufyController : BaseController {
        #region 注入服务
        public TradeRep tradeRep { get; set; }

        public UserAccountRep userAccountRep { get; set; }
        #endregion
        [Route("TradeNotify")]
        public ActionResult TradeNotify(string resp_code, string resp_desc, string platform_seq_id, string ord_id, string trans_amt,string mer_priv) {
            string strinfo = resp_code + "|" + resp_desc + "|" + ord_id + "|" + platform_seq_id + "|" + trans_amt+"|"+ mer_priv;
            var userAccountId = int.Parse(mer_priv);
            LoggerFactory.Instance.Logger_Info(strinfo, "TradeNotify");
            if (resp_code == "000" || resp_code == "100") {
                tradeRep.UpdateState(1, ord_id, platform_seq_id);
                var userAccount = userAccountRep.GetUserAccount(new UserAccount() {  UserAccountId = userAccountId });
                var totalIntegral = (int)((int)userAccount.Integral + decimal.Parse(trans_amt) / 1000);
                var Memberlevel = RetrueMemberlevel(totalIntegral);
                if (Memberlevel> userAccount.Memberlevel) {
                    userAccountRep.AddIntegral(userAccountId, totalIntegral, Memberlevel);
                } else {
                    userAccountRep.AddIntegral(userAccountId, totalIntegral, null);
                }
                return Content("ECHO_SEQ_ID=" + ord_id);
            } else {
                tradeRep.UpdateStateFail(2, ord_id, platform_seq_id);
                LoggerFactory.Instance.Logger_Info(strinfo, "TradeNotifyFail");
                return Content("ECHO_SEQ_ID=");
            }
        }
        public int RetrueMemberlevel(int Integral) {

            if (Integral >= 100 && Integral < 500) {
                return 1;
            } else if (Integral >= 500 && Integral < 1000) {
                return 2;
            } else if (Integral >= 1000 && Integral < 2000) {
                return 3;
            } else if (Integral >= 2000 && Integral < 5000) {
                return 4;
            } else if (Integral >= 5000) {
                return 5;
            } else {
                return 0;
            }

        }
    }
}
