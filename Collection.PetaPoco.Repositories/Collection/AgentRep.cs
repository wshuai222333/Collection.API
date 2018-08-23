using Collection.Entity.CollectionModel;
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
WHERE   1 = 1
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
    }
}
