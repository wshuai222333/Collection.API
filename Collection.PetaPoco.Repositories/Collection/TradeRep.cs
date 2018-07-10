using Collection.Entity.CollectionModel;
using PetaPoco.NetCore;
using System.Collections.Generic;

namespace Collection.PetaPoco.Repositories.Collection {
    public class TradeRep
    {
        public object Insert(Trade model) {
            return CollectionDB.GetInstance().Insert(model);
        }

        public int Update(UserAccount model) {
            return CollectionDB.GetInstance().Update(model);
        }

        public int UpdateState(int State,string OrderId,string PlatFormId) {
            string sql = "set State=@0,PlatFormId=@2 where [TradeOrderId]=@1";
            return CollectionDB.GetInstance().Update<Trade>(sql, State, OrderId, PlatFormId);
        }
       
        public Page<Trade> GetTradeList(int pageindex, int pagesize,int? UserAccountId) {
            string sql = string.Empty;
            string wherestr = string.Empty;
            if (UserAccountId != null) {
                wherestr += "and UserAccountId =@0";
            }
            
            sql = string.Format(@"
SELECT  *
FROM    dbo.Trade
WHERE 1=1 {0}
ORDER BY CreateTime DESC", wherestr);
            return CollectionDB.GetInstance().Page<Trade>(pageindex, pagesize, sql, UserAccountId);
        }
    }
}
