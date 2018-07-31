using Collection.Api.DTO.Trade;
using Collection.PetaPoco.Repositories.Collection;
using System;  
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.Service.Trade {
    public class DeleteBankCardService : ApiOriBase<RequestDeleteBankCard> {
        #region 注入服务
        public BankCardRep bankCardRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            this.Result.Data = bankCardRep.Delete(this.Parameter.BankCardId);
        }
    }
}
