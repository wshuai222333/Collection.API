using Collection.Api.DTO.Trade;
using Collection.PetaPoco.Repositories.Collection;

namespace Collection.Api.Service.Trade {
    public class GetBankCardListService : ApiOriBase<RequestGetBankCardList> {
        #region 注入服务
        public BankCardRep bankCardRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            this.Result.Data = bankCardRep.GetBankCardList(this.Parameter.UserAccountId);
        }
    }
}
