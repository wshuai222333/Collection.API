using Collection.Api.DTO.Trade;
using Collection.DDD.Config;
using Collection.Dingshuapay.Service;
using Collection.Entity.CollectionModel;
using Collection.PetaPoco.Repositories.Collection;
using System;

namespace Collection.Api.Service.Trade {
    public class TradePayService : ApiOriBase<RequestTradePay> {
        #region 注入服务
        public TradeRep tradeRep { get; set; }

        public AgentTradeRep agentTradeRep { get; set; }

        PayProcessor payProcessor = new PayProcessor();
        #endregion

        protected override void ExecuteMethod() {
            var agentTrade = new AgentTrade() {
                AcctCardNo = this.Parameter.AcctCardno,
                AcctIdCard = this.Parameter.AcctCardno,
                AcctName = this.Parameter.AcctName,
                AgentId = 0,
                Amount = decimal.Parse(this.Parameter.TransAmt),
                BankName = this.Parameter.BankNum,
                BankNum = this.Parameter.BankNum,
                BgRetUrl = this.Parameter.BgRetUrl,
                CardId = this.Parameter.CardId,
                CreateTime = DateTime.Now,
                MobileNo = this.Parameter.MobileNo,
                RetUrl = this.Parameter.RetUrl,
                State = 0,
                TradeOrderId = this.Parameter.OrderId,
                TradeRate = decimal.Parse(JsonConfig.JsonRead("trade_rate", "Dingshuapay"))
            };
            agentTradeRep.Insert(agentTrade);
            this.Result.Data = payProcessor.ExecuteForm(this.Parameter);
        }
    }
}
