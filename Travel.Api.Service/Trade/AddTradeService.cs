using Collection.Api.DTO.Trade;
using Collection.PetaPoco.Repositories.Collection;
using System;

namespace Collection.Api.Service.Trade {
    public class AddTradeService : ApiOriBase<RequestAddTrade> {
        #region 注入服务
        public TradeRep tradeRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            var trade = new Entity.CollectionModel.Trade() {
                AcctCardNo = this.Parameter.AcctCardNo,
                AcctIdCard = this.Parameter.AcctIdCard,
                AcctName = this.Parameter.AcctName,
                Amount = this.Parameter.Amount,
                BankName = this.Parameter.BankName,
                BankNum = this.Parameter.BankNum,
                CardId = this.Parameter.CardId,
                CreateTime = DateTime.Now,
                MobileNo = this.Parameter.MobileNo,
                TradeOrderId = this.Parameter.TradeOrderId,
                TradeRate = this.Parameter.TradeRate,
                TradeRateCode = this.Parameter.TradeRateCode,
                UserAccountId = this.Parameter.UserAccountId,
                State = 0,
                IsQrcode = this.Parameter.IsQrcode,
                Rate = this.Parameter.Rate,
                Poundage = this.Parameter.Amount * this.Parameter.TradeRate/ 1000,
                Profits = this.Parameter.Amount * (this.Parameter.TradeRate - this.Parameter.Rate) / 1000
            };
            this.Result.Data = tradeRep.Insert(trade);
        }
    }
}
