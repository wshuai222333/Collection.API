using Collection.Api.DTO.Middle;
using Collection.Api.DTO.Trade;
using Collection.DDD.Logger;
using Collection.DDD.Utils.Http;
using Collection.Entity.CollectionModel;
using Collection.PetaPoco.Repositories.Collection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using static Collection.DDD.Utils.Http.HttpRequest;

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {

            UserAccountRep userAccountRep = new UserAccountRep();
            string mer_priv = "2";
            var trans_amt = "16000.00";
            var userAccountId = int.Parse(mer_priv);
            var userAccount = userAccountRep.GetUserAccount(new UserAccount() { UserAccountId = userAccountId });
            var totalIntegral = (int)((int)userAccount.Integral + decimal.Parse(trans_amt) / 1000);

            var Memberlevel = this.RetrueMemberlevel(totalIntegral);
            if (Memberlevel > userAccount.Memberlevel) {
                userAccountRep.AddIntegral(userAccountId, totalIntegral, Memberlevel);
            } else {
                userAccountRep.AddIntegral(userAccountId, totalIntegral, null);
            }
        }
        public int RetrueMemberlevel(int Integral) {

            if (Integral >= 10 && Integral < 50) {
                return 1;
            } else if (Integral >= 50 && Integral < 100) {
                return 2;
            } else if (Integral >= 100 && Integral < 200) {
                return 3;
            } else if (Integral >= 200 && Integral < 500) {
                return 4;
            } else if (Integral >= 500) {
                return 5;
            } else {
                return 0;
            }
        }
        [TestMethod]
        public void TestMethod2() {

            var agentTradeRep = new AgentTradeRep();
            string ord_id = "20180808134120";
            string platform_seq_id = "123123";
            var res = agentTradeRep.UpdateState(1, ord_id, platform_seq_id);
            var agentTrade = agentTradeRep.GetAgentTrade(new AgentTrade() { TradeOrderId = ord_id });

            var agentResponseModel = new AgentResponseModel() {
                Extension = "extension",
                MerPriv = "mer_priv",
                OrderId = ord_id,
                PlatformId = platform_seq_id,
                RespCode = "resp_code",
                RespDesc = "resp_desc",
                TransAmt = "trans_amt",
                AgentId = agentTrade.AgentId.ToString()
            };
            string content = JsonConvert.SerializeObject(agentResponseModel);
            //string result = HttpRequestUtility.SendPostRequest(agentTrade.BgRetUrl, content, "UTF-8", 10000);
            string result = apiPost(agentTrade.BgRetUrl, content);
            //LoggerFactory.Instance.Logger_Info(agentTrade + "|" + ord_id + "|" + result, "TradeNotifyresult");
        }
        /// <summary>
        /// Post提交
        /// </summary>
        /// <param name="requestURL">请求地址</param>
        /// <param name="requestData">请求数据</param>
        /// <returns></returns>
        public string apiPost(string requestURL, string requestData) {
            byte[] byteArray = Encoding.UTF8.GetBytes(requestData);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(requestURL));
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.Timeout = 300000;
            System.IO.Stream newStream = webRequest.GetRequestStreamAsync().Result;
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Dispose();
            HttpWebResponse response;
            try {
                response = (HttpWebResponse)webRequest.GetResponseAsync().Result;
            } catch (WebException ex) {
                response = (HttpWebResponse)ex.Response;
            }
            var data = new System.IO.StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();
            response.Close();
            return data;
        }
        [TestMethod]
        public void TestPostPay() {
            var data = new RequestTradePay() {
                AcctCardno = "111",
                AcctIdcard = "123123",
                AcctName = ""

            };
            string RequestEncodingName = "UTF-8";
            string ParameterEncodingName = "UTF-8";
            var encoding = System.Text.Encoding.GetEncoding(ParameterEncodingName);
            string html = HttpRequest.HttpRequestUtility.SendPostRequestCore("http://localhost:1184/Pay/Pay", JsonConvert.SerializeObject(data), RequestEncodingName, null);
            string ss = html;
        }
    }
}
