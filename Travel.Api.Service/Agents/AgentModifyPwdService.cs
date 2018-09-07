using Collection.Api.DTO.Agent;
using Collection.Entity.CollectionModel;
using System;

namespace Collection.Api.Service.Agents {
    public class AgentModifyPwdService : ApiOriBase<RequestAgentModifyPassword> {
        #region 注入服务

        #endregion
        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            var agent = new Agent() {
                AgentId = this.Parameter.AgentModifyId,
                UserPwd = this.Parameter.OldUserPwd,
            };
            var user = agentRep.GetAgent(agent);
            if (user != null) {
                user.UserPwd = this.Parameter.UserPwd;
                this.Result.Data = agentRep.Update(user);
            } else {
                throw new AggregateException("旧密码错误！");
            }

        }
    }
}
