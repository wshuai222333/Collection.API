using Collection.Api.DTO.User;
using Collection.Entity.CollectionModel;
using Collection.PetaPoco.Repositories.Collection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.Service.User {
    public class AdminLoginService : ApiOriBase<RequestAdminLogin> {
        #region 注入服务
        public AdminRep adminRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            var admin = new Admin() {
                UserName = this.Parameter.UserName,
                UserPwd = this.Parameter.UserPwd,
             };
            var user = adminRep.GetAdminLogin(admin);
            if (user != null) {
                this.Result.Data = user;
            } else {
                throw new AggregateException("用户名或密码不正确！");
            }

        }
    }
}
