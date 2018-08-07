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
        public ActionResult Pay(string Subject, string TransAmt, string CardId, string MobileNo, string AcctName, string AcctIdcard, string BankNum, string AcctCardno, string RetUrl, string BgRetUrl, string MerPriv, string Extension, string OrderId) {
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
                RetUrl = RetUrl
            };
            var data = tradePayService.Execute(model).Data;
            return Content(data.ToString(), "text/html");
        }
    }
}
