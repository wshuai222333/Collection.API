using Collection.Api.DTO.User;
using Collection.Entity.CollectionModel;
using Collection.PetaPoco.Repositories.Collection;

namespace Collection.Api.Service.User {
    public class DeleteProblemService : ApiOriBase<RequestDeleteProblem> {
        #region 注入服务
        public ProblemRep problemRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            this.Result.Data = problemRep.Delete(new Problem() {
                ProblemId = this.Parameter.ProblemId
            });
        }
    }
}
