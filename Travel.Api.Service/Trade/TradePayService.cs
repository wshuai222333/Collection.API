﻿using Collection.Api.DTO.Trade;
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
                TradeRate = decimal.Parse(JsonConfig.JsonRead("trade_rate", "Dingshuapay")),
                Subject = this.Parameter.Subject
            };
            agentTradeRep.Insert(agentTrade);
            this.Result.Data = payProcessor.ExecuteForm(this.Parameter);
        }
    }
}
