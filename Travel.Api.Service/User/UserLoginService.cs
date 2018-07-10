using Collection.Entity.CollectionModel;
using Collection.PetaPoco.Repositories.Collection;
using CollectionApi.DTO.User;
using System;

namespace Collection.Api.Service.User {
    public class UserLoginService : ApiOriBase<RequestUserLoginModel> {
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
                UserName = this.Parameter.UserName,
                UserPwd = this.Parameter.UserPwd
            };
            var user = userAccountRep.GetUserAccount(useraccount);
            if (user!=null) {
                this.Result.Data = userAccountRep.GetUserAccount(useraccount);
            } else {
                throw new AggregateException("用户名或密码不正确！");
            }
            
        }
    }
}
