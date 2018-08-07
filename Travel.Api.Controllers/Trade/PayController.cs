using Collection.Api.DTO.Trade;
using Collection.Api.Service.Trade;
using Collection.Dingshuapay.Service;
using Microsoft.AspNetCore.Mvc;

namespace Collection.Api.Controllers.Trade {
    [Route("Pay")]
    //[Produces("application/json")]
    //[EnableCors("AllowSameDomain")]
    public class PayController : Controller {
        #region 注入服务
        public TradePayService tradePayService { get; set; }

        #endregion
        [HttpPost]
        public ActionResult Pay(string Subject, string TransAmt, string CardId, string MobileNo, string AcctName, string AcctIdcard, string BankNum, string AcctCardno, string RetUrl, string BgRetUrl, string MerPriv, string Extension, string OrderId, string AgentId,string Ip,string Mac,string TimesTamp,string Sign,string Version) {
            var model = new RequestTradePay() {
                AcctCardno = AcctCardno,
                AcctIdcard = AcctIdcard,
                AcctName = AcctName,
                BankNum = BankNum,
                BgRetUrl = BgRetUrl,
                CardId = CardId,
                Extension = Extension,
                MerPriv = MerPriv,
                MobileNo = MobileNo,
                OrderId = OrderId,
                TransAmt = TransAmt,
                Subject = Subject,
                RetUrl = RetUrl,
                AgentId = AgentId,
                Ip = Ip,
                Mac = Mac,
                TimesTamp = TimesTamp,
                Sign = Sign,
                Version = Version
            };
            var data = tradePayService.Execute(model);
            var Data = "异常结果";
            if (data.Status == 100) {
                Data = data.Data.ToString();
            } else {
                Data = data.Message;
            }
            return Content(Data, "text/html");
        }
    }
}
