using Collection.Api.DTO.User;
using Collection.Entity.CollectionModel;
using Collection.PetaPoco.Repositories.Collection;
using System;

namespace Collection.Api.Service.User {
    public class AddProblemService : ApiOriBase<RequestAddProblem> {
        #region 注入服务
        public ProblemRep problemRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            if (this.Parameter.ProblemId > 0) {
                this.Result.Data = problemRep.UpdateProblem(new Problem() {
                    ProblemId = this.Parameter.ProblemId,
                    MotifyTime = DateTime.Now,
                    Body = this.Parameter.Body,
                    Title = this.Parameter.Title
                });
            } else {
                this.Result.Data = problemRep.Insert(new Problem() {
                    Title = this.Parameter.Title,
                    Body = this.Parameter.Body,
                    CreateTime = DateTime.Now,
                    MotifyTime = DateTime.Now
                });
            }
          
        }
    }
}
