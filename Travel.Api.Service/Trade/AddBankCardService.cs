using Collection.Api.DTO.Trade;
using Collection.Entity.CollectionModel;
using Collection.PetaPoco.Repositories.Collection;

namespace Collection.Api.Service.Trade {
    public class AddBankCardService : ApiOriBase<RequestAddBankCard> {
        #region 注入服务
        public BankCardRep bankCardRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            var bankCard = new BankCard() {
                AcctName = this.Parameter.AcctName,
                BankCode = this.Parameter.BankCode,
                BankName = this.Parameter.BankName,
                CardId = this.Parameter.CardId,
                Phone = this.Parameter.Phone,
                Type = this.Parameter.Type,
                UserAccountId = this.Parameter.UserAccountId
            };
            this.Result.Data = bankCardRep.Insert(bankCard);
        }
    }
}
