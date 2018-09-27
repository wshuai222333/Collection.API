using Collection.Api.DTO.Agent;
using System;
using System.Collections.Generic;
using System.Text;
using Collection.Entity.CollectionModel;

namespace Collection.Api.Service.Agents {
    public class AddAgentService : ApiOriBase<RequestAddAgent> {

        /// <summary>
        /// 执行方法
        /// </summary>
        protected override void ExecuteMethod() {
            var agent = new Agent() {
                CreateTime = DateTime.Now,
                MerchantName = this.Parameter.MerchantName,
                Phone = this.Parameter.Phone,
                Rate = this.Parameter.Rate,
                UserKey = Guid.NewGuid().ToString().Replace("-", "").ToUpper(),
                UserName = "admin",
                UserPwd = "123456",
                AgentId = this.Parameter.AddAgentId,
                State = 1
            };
            if (this.Parameter.AddAgentId > 0) {
                this.Result.Data = agentRep.UpdateAgent(agent);
            } else {
                this.Result.Data = agentRep.Add(agent);
            }

        }
    }
}
