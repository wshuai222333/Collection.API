using Collection.Entity.CollectionModel;
using PetaPoco.NetCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.PetaPoco.Repositories.Collection
{
    public class AgentTradeRep
    {
        public object Insert(AgentTrade model) {
            return CollectionDB.GetInstance().Insert(model);
        }
        public int UpdateState(int State, string OrderId, string PlatFormId) {
            string sql = "set State=@0,PlatFormId=@2 where [TradeOrderId]=@1";
            return CollectionDB.GetInstance().Update<AgentTrade>(sql, State, OrderId, PlatFormId);
        }

        public Page<AgentTrade> GetTradeList(int pageindex, int pagesize, int? AgentId, int State) {
            string sql = string.Empty;
            string wherestr = string.Empty;
            if (AgentId != null) {
                wherestr += "and AgentId =@0 ";
            }
            if (State > -1) {
                wherestr += "and State =@1 ";
            }
            sql = string.Format(@"
SELECT  *
FROM    dbo.TraAgentTradede
WHERE 1=1 {0}
ORDER BY CreateTime DESC", wherestr);
            return CollectionDB.GetInstance().Page<AgentTrade>(pageindex, pagesize, sql, AgentId, State);
        }
    }
}
