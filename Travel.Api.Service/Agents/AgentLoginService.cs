using Collection.Api.DTO.Agent;
using Collection.Entity.CollectionModel;
using System;


namespace Collection.Api.Service.Agents {
    public class AgentLoginService : ApiOriBase<RequestAgentLogin> {
        #region 注入服务
  
        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            var agent = new Agent() {
                UserName = this.Parameter.UserName,
                UserPwd = this.Parameter.UserPwd,
                AgentId = this.Parameter.AngetLoginId
            };
            var user = agentRep.GetAgentLogin(agent);
            if (user != null) {
                this.Result.Data = user;
            } else {
                throw new AggregateException("用户名或密码不正确！");
            }

        }
    }
}
