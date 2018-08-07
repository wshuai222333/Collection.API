using Collection.Entity.CollectionModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.PetaPoco.Repositories.Collection {
    public class AgentRep {

        public Agent GetAgent(Agent model) {
            #region sql
            string wherestr = string.Empty;

            if (model.AgentId > 0) {
                wherestr += " AND AgentId = @0 ";
            }
            string sql = string.Format(@"
SELECT  *
FROM    [dbo].[Agent]
WHERE   1 = 1
        {0} ", wherestr);
            #endregion

            var agent = CollectionDB.GetInstance().SingleOrDefault<Agent>(sql,
                model.AgentId);
            return agent;
        }
    }
}
