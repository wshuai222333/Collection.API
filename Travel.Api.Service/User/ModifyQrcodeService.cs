using Collection.Api.DTO.User;
using Collection.PetaPoco.Repositories.Collection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.Service.User {
    public class ModifyQrcodeService : ApiOriBase<RequestModifyIsQrcode> {
        #region 注入服务
        public UserAccountRep userAccountRep { get; set; }
        #endregion

        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            this.Result.Data = userAccountRep.UpdateIsQrcode(this.Parameter.UserAccountId, this.Parameter.IsQrcode,this.Parameter.Rate,this.Parameter.DrawFee);
        }
    }
}
