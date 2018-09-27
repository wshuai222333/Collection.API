using Collection.Api.DTO.Trade;
using Collection.PetaPoco.Repositories.Collection;
using System.Linq;

namespace Collection.Api.Service.Trade {
    public class GetTradeListTotalService : ApiOriBase<RequestGetTradeList> {
        #region 注入服务
        public TradeRep tradeRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            var list= tradeRep.GetTradeLists(this.Parameter.UserAccountId, 1,this.Parameter.IsQrcode,this.Parameter.BeginTime,this.Parameter.EndTime);
            this.Result.Data = new {
                TotalAmount = list.Sum(i=>i.Amount),
                TotalProfits = list.Sum(i=>i.Profits),
                TotalDrawFeeTotalProfits = list.Sum(i=>i.DrawFeePoundage)
            };
        }
    }
}
