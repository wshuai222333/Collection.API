using Collection.Api.DTO.User;
using Collection.Entity.CollectionModel;
using Collection.PetaPoco.Repositories.Collection;
using System;

namespace Collection.Api.Service.User {
    public class ModifyProblemService : ApiOriBase<RequestModifyProblem> {
        #region 注入服务
        public ProblemRep problemRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            this.Result.Data = problemRep.Update(new Problem() {
                ProblemId = this.Parameter.ProblemId,
                MotifyTime = DateTime.Now,
                Body = this.Parameter.Body,
                Title = this.Parameter.Title
            });
        }
    }
}
