using Collection.Api.DTO.User;
using Collection.PetaPoco.Repositories.Collection;

namespace Collection.Api.Service.User {
    public class ModifyMemberlevelService : ApiOriBase<RequestModifyMemberlevel> {
        #region 注入服务
        public UserAccountRep userAccountRep { get; set; }
        #endregion

        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            this.Result.Data =  userAccountRep.UpdateMemberlevel(this.Parameter.UserAccountId, this.Parameter.Memberlevel);
        }
    }
}
