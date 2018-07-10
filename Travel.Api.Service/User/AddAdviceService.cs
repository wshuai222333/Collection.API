using Collection.Api.DTO.User;
using Collection.Entity.CollectionModel;
using Collection.PetaPoco.Repositories.Collection;

namespace Collection.Api.Service.User {
    public class AddAdviceService : ApiOriBase<RequestAddAdvice> {
        #region 注入服务
        public AdviceRep adviceRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            this.Result.Data = adviceRep.Insert(new Advice() {
                AdviceContent = this.Parameter.AdviceContent,
                UserAccountId = this.Parameter.UserAccountId
            });
        }
    }
}
