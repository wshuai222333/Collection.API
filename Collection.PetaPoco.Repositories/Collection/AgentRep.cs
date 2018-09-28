using Collection.Entity.CollectionModel;
using PetaPoco.NetCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.PetaPoco.Repositories.Collection {
    public class AgentRep {
        public object Add(Agent model) {
            return CollectionDB.GetInstance().Insert(model);
        }
        public int Update(Agent model) {
            return CollectionDB.GetInstance().Update(model);
        }
        public Agent GetAgent(Agent model) {
            #region sql
            string wherestr = string.Empty;

            if (model.AgentId > 0) {
                wherestr += " AND AgentId = @0 ";
            }
            if (!string.IsNullOrWhiteSpace(model.UserPwd)) {
                wherestr += " AND UserPwd = @1 ";
            }
            string sql = string.Format(@"
SELECT  *
FROM    [dbo].[Agent]
WHERE   1 = 1 AND State=1
        {0} ", wherestr);
            #endregion

            var agent = CollectionDB.GetInstance().FirstOrDefault<Agent>(sql,
                model.AgentId, model.UserPwd);
            return agent;
        }
        public Agent GetAgentLogin(Agent model) {
            #region sql
            string wherestr = string.Empty;
            if (!string.IsNullOrEmpty(model.UserName)) {
                wherestr += " AND UserName = @0";
            }
            if (!string.IsNullOrEmpty(model.UserPwd)) {
                wherestr += " AND UserPwd = @1 ";
            }
            if (model.AgentId > 0) {
                wherestr += " AND AgentId  = @2";
            }
            string sql = string.Format(@"
            SELECT  *
            FROM    dbo.Agent
            WHERE   1 = 1
            {0}
            ", wherestr);
            #endregion
            return CollectionDB.GetInstance().SingleOrDefault<Agent>(sql,
                              model.UserName, model.UserPwd, model.AgentId);
        }
        public Page<Agent> GetAgentListByPage(int pageindex, int pagesize) {
            #region sql
            string wherestr = string.Empty;
            string sql = string.Format(@"
            SELECT  *
            FROM    dbo.Agent
            WHERE   1 = 1
            {0}
            ORDER BY CreateTime DESC
            ", wherestr);
            #endregion
            return CollectionDB.GetInstance().Page<Agent>(pageindex, pagesize, sql);
        }
        public List<Agent> GetAgentList() {
            #region sql
            string wherestr = string.Empty;
            string sql = string.Format(@"
            SELECT  *
            FROM    dbo.Agent
            WHERE   1 = 1
            {0}
            ORDER BY CreateTime DESC
            ", wherestr);
            #endregion
            return CollectionDB.GetInstance().Fetch<Agent>(sql);
        }
        public int UpdateAgent(Agent agent) {
            #region sql
            string wherestr = string.Empty;
            wherestr += "AND AgentId = " + agent.AgentId;
            string modifystr = string.Empty;
            string sql = string.Format(@"
            SET MerchantName=@0,Rate = @1,Phone=@2
            WHERE 1 = 1
            {0}
             ", wherestr);
            #endregion
            return CollectionDB.GetInstance().Update<Agent>(sql,agent.MerchantName,agent.Rate,agent.Phone);
        }
        public int UpdateAgentState(int AgentId,int State) {
            #region sql
            string wherestr = string.Empty;
            wherestr += "AND AgentId = " + AgentId;
            string modifystr = string.Empty;
            string sql = string.Format(@"
            SET State=@0
            WHERE 1 = 1
            {0}
             ", wherestr);
            #endregion
            return CollectionDB.GetInstance().Update<Agent>(sql, State);
        }
    }
}
