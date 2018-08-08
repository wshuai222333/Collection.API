using Collection.Api.DTO.Trade;
using Collection.DDD.Config;
using System.Text;
using Collection.DDD;
using System.Web;

namespace Collection.Dingshuapay.Service {
    public class PayProcessor {
        /// <summary>
        /// 执行操作form提交数据
        /// </summary>
        /// <returns></returns>    
        public string ExecuteForm(RequestTradePay pay) {
            var UrlNotify = JsonConfig.JsonRead("bg_ret_url", "Dingshuapay");
            Encoding utf8 = Encoding.UTF8;
            string checkstr = 
                  JsonConfig.JsonRead("version", "Dingshuapay")
                + JsonConfig.JsonRead("cust_id", "Dingshuapay")
                + pay.OrderId
                + pay.AcctIdcard
                + pay.Subject
                + JsonConfig.JsonRead("gate_id", "Dingshuapay")
                + pay.TransAmt
                + pay.CardId
                + pay.MobileNo
                + pay.AcctName
                + pay.AcctIdcard
                + pay.BankNum
                + pay.AcctCardno
                + pay.TradeRate
                + pay.DrawFee
                + pay.RetUrl
                + this.UrlEncode(UrlNotify, utf8, true)
                + pay.MerPriv
                + pay.Extension
                + JsonConfig.JsonRead("userkey", "Dingshuapay");
            string check_value = Encrpty.MD5Encrypt(checkstr);
            StringBuilder sbHtml = new StringBuilder();

            sbHtml.Append("<form action='" + JsonConfig.JsonRead("DingshuapayUrl", "Dingshuapay") + "' method='post' name='merRecvRequest' >");
            sbHtml.Append("<input type='hidden' name='version' value='" + JsonConfig.JsonRead("version", "Dingshuapay") + "'/>");
            sbHtml.Append("<input type='hidden' name='cust_id' value='" + JsonConfig.JsonRead("cust_id", "Dingshuapay") + "'/>");
            sbHtml.Append("<input type='hidden' name='ord_id' value='" + pay.OrderId + "'/>");
            sbHtml.Append("<input type='hidden' name='sub_mer_id' value='" + pay.AcctIdcard + "'/>");
            sbHtml.Append("<input type='hidden' name='subject' value='" + pay.Subject + "'/>");
            sbHtml.Append("<input type='hidden' name='gate_id' value='" + JsonConfig.JsonRead("gate_id", "Dingshuapay") + "'/>");
            sbHtml.Append("<input type='hidden' name='trans_amt' value='" + pay.TransAmt + "'/>");
            sbHtml.Append("<input type='hidden' name='card_id' value='" + pay.CardId + "'/>");
            sbHtml.Append("<input type='hidden' name='mobile_no' value='" + pay.MobileNo + "'/>");
            sbHtml.Append("<input type='hidden' name='acct_name' value='" + pay.AcctName + "'/>");
            sbHtml.Append("<input type='hidden' name='acct_idcard' value='" + pay.AcctIdcard + "'/>");
            sbHtml.Append("<input type='hidden' name='bank_num' value='" + pay.BankNum + "'/>");
            sbHtml.Append("<input type='hidden' name='acct_cardno' value='" + pay.AcctCardno + "'/>");
            sbHtml.Append("<input type='hidden' name='trade_rate' value='" + pay.TradeRate + "'/>");
            sbHtml.Append("<input type='hidden' name='draw_fee' value='" + pay.DrawFee + "'/>");
            sbHtml.Append("<input type='hidden' name='ret_url' value='" + pay.RetUrl + "'/>");
            sbHtml.Append("<input type='hidden' name='bg_ret_url' value='" + this.UrlEncode(UrlNotify, utf8, true) + "'/>");
            sbHtml.Append("<input type='hidden' name='mer_priv' value='" + pay.MerPriv + "'/>");
            sbHtml.Append("<input type='hidden' name='extension' value='" + pay.Extension + "'/>");
            sbHtml.Append("<input type='hidden' name='check_value' value='" + check_value + "'/>");
            sbHtml.Append("</form>");
            sbHtml.Append("<script>document.forms['merRecvRequest'].submit();</script> ");

            //CGT.DDD.Logger.LoggerFactory.Instance.Logger_Info(string.Format(@"提交参数:{0},提交加密参数:{1}", json, sbHtml.ToString()), "ReapalRecharge");
            return sbHtml.ToString();
        }
        private string UrlEncode(string strSrc, System.Text.Encoding encoding, bool bToUpper) {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < strSrc.Length; i++) {
                string t = strSrc[i].ToString();
                string k = HttpUtility.UrlEncode(t, encoding);
                if (t == k) {
                    stringBuilder.Append(t);
                } else {
                    if (bToUpper)
                        stringBuilder.Append(k.ToUpper());
                    else
                        stringBuilder.Append(k);
                }
            }
            if (bToUpper)
                return stringBuilder.ToString().Replace("+", "%2B");
            else
                return stringBuilder.ToString();
        }
    }
}
