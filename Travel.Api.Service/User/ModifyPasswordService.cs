using Collection.Api.DTO.User;
using Collection.Entity.CollectionModel;
using Collection.PetaPoco.Repositories.Collection;
using System;

namespace Collection.Api.Service.User {

    public class ModifyPasswordService : ApiOriBase<RequestModifyPassword> {

        #region 注入服务
        public UserAccountRep userAccountRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            var useraccount = new UserAccount() {
                UserName = this.Parameter.UserName,
                UserPwd = this.Parameter.OldUserPwd
            };
            var user = userAccountRep.GetUserAccount(useraccount);
            if (user != null) {
                user.UserPwd = this.Parameter.UserPwd;
                this.Result.Data = userAccountRep.Update(user);
            } else {
                throw new AggregateException("旧密码错误！");
            }

        }


    }
}
