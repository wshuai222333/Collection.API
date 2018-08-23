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
            if (decimal.Parse(this.Parameter.TradeRate) < decimal.Parse(JsonConfig.JsonRead("trade_rate", "Dingshuapay"))) {
                throw new AggregateException("手续费费率小于协议费率");
            }
            if (decimal.Parse(this.Parameter.DrawFee) < decimal.Parse(JsonConfig.JsonRead("draw_fee", "Dingshuapay"))) {
                throw new AggregateException("提现手续小于协议费用");
            }
            if (decimal.Parse(this.Parameter.TransAmt) < 300) {
                throw new AggregateException("交易金额不能小于300");
            }
            if (agentTradeRep.GetAgentTrade(new AgentTrade() { OrderId = this.Parameter.AgentId+this.Parameter.OrderId })!=null) {
                throw new AggregateException("订单号重复");
            }
            var agentTrade = new AgentTrade() {
                AcctCardNo = this.Parameter.AcctCardno,
                AcctIdCard = this.Parameter.AcctIdcard,
                AcctName = this.Parameter.AcctName,
                AgentId = int.Parse(this.Parameter.AgentId),
                Amount = decimal.Parse(this.Parameter.TransAmt),
                BankNum = this.Parameter.BankNum,
                BgRetUrl = this.Parameter.BgRetUrl,
                CardId = this.Parameter.CardId,
                CreateTime = DateTime.Now,
                MobileNo = this.Parameter.MobileNo,
                RetUrl = this.Parameter.RetUrl,
                State = 0,
                TradeOrderId = this.Parameter.OrderId,
                TradeRate = decimal.Parse(this.Parameter.TradeRate),
                Subject = this.Parameter.Subject,
                DrawFee = decimal.Parse(this.Parameter.DrawFee),
                MerPriv = this.Parameter.MerPriv,
                Extension = this.Parameter.Extension,
                OrderId = this.Parameter.AgentId + this.Parameter.OrderId,
                AgentRate = agent.Rate,
                Poundage = decimal.Parse(this.Parameter.TransAmt) * decimal.Parse(this.Parameter.TradeRate)/1000,
                Profits = decimal.Parse(this.Parameter.TransAmt) * (decimal.Parse(this.Parameter.TradeRate)- agent.Rate) / 1000
            };
            agentTradeRep.Insert(agentTrade);
            this.Result.Data = payProcessor.ExecuteForm(this.Parameter);
        }
    }
}
