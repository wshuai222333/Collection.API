using Collection.Api.DTO.User;
using Collection.Entity.CollectionModel;
using Collection.PetaPoco.Repositories.Collection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.Service.User
{
    public class GetProblemService : ApiOriBase<RequestGetProblem> {
        #region 注入服务
        public ProblemRep problemRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {

            this.Result.Data = problemRep.GetProblem(new Problem() {
                 ProblemId = this.Parameter.ProblemId
            });
        }
    }
}
