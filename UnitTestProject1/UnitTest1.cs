using Collection.Api.DTO.Trade;
using Collection.DDD.Utils.Http;
using Collection.Entity.CollectionModel;
using Collection.PetaPoco.Repositories.Collection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

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
            var totalIntegral =(int)((int)userAccount.Integral + decimal.Parse(trans_amt) / 1000);
            
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
        public void TestPostPay() {
            var data = new RequestTradePay() {
               AcctCardno="111",
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
