using Collection.Api.DTO.User;
using Collection.PetaPoco.Repositories.Collection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.Service.User
{
    public  class GetProblemListService : ApiOriBase<RequestGetProblemList> {
        #region 注入服务
        public ProblemRep problemRep { get; set; }
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {

            this.Result.Data = problemRep.GetProblemList(this.Parameter.pageindex, this.Parameter.pagesize, this.Parameter.Title);
        }
    }
}
