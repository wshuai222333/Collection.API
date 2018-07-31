using Collection.Api.DTO.Trade;
using Collection.Entity.CollectionModel;
using Collection.PetaPoco.Repositories.Collection;
using System;

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
                UserAccountId = this.Parameter.UserAccountId,
                CreateTime = DateTime.Now,
                AcctIdCard = this.Parameter.AcctIdCard
            };
            if (bankCardRep.GetBankCard(bankCard)!=null) {
                throw new AggregateException("卡号已存在，请检查卡号！");
            } 
            this.Result.Data = bankCardRep.Insert(bankCard);

        }
    }
}
