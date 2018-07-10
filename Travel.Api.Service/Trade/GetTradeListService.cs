using Collection.Api.DTO.Trade;
using Collection.PetaPoco.Repositories.Collection;

namespace Collection.Api.Service.Trade {
    public class GetTradeListService : ApiOriBase<RequestGetTradeList> {
        #region 注入服务
        public TradeRep tradeRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
          
            this.Result.Data = tradeRep.GetTradeList(this.Parameter.pageindex,this.Parameter.pagesize,this.Parameter.UserAccountId);
        }
    }
}
