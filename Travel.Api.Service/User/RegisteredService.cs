
using CollectionApi.DTO.User;
using System.Linq;
using System;
using Collection.PetaPoco.Repositories.Collection;
using Collection.Entity.CollectionModel;

namespace Collection.Api.Service.User {
    public class RegisteredService : ApiOriBase<RequestRegisteredModel> {
        #region 注入服务
        public UserAccountRep userAccountRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            var useraccount = new UserAccount() {
                CreateTime = DateTime.Now,
                Memberlevel = 0,
                ModifyTime = DateTime.Now,
                Phone = this.Parameter.UserPhone,
                UserName = this.Parameter.UserName,
                UserPwd = this.Parameter.UserPwd,
                Integral = 0,
                IsQrcode = 0
             };
            var user = userAccountRep.GetUserAccount(useraccount);
            if (user != null) {
                throw new AggregateException("用户名或手机号已重复！");
            }

            this.Result.Data = userAccountRep.Insert(useraccount);
        }
    }
}
