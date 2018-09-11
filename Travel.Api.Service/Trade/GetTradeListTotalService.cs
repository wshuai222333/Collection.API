using Collection.Api.DTO.Trade;
using Collection.PetaPoco.Repositories.Collection;
using System;
using System.Collections.Generic;
using System.Text;
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
            this.Result.Data = tradeRep.GetTradeLists(this.Parameter.UserAccountId, this.Parameter.State,this.Parameter.IsQrcode,this.Parameter.BeginTime,this.Parameter.EndTime).Sum(i=>i.Profits);
        }
    }
}
