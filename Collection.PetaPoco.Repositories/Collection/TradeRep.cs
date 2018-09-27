using Collection.Entity.CollectionModel;
using PetaPoco.NetCore;
using System;
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
            string sql = "set State=@0,PlatFormId=@2,TradeTime=getdate() where [TradeOrderId]=@1";
            return CollectionDB.GetInstance().Update<Trade>(sql, State, OrderId, PlatFormId);
        }
        public int UpdateStateFail(int State, string OrderId, string PlatFormId) {
            string sql = "set State=@0,PlatFormId=@2 where [TradeOrderId]=@1";
            return CollectionDB.GetInstance().Update<Trade>(sql, State, OrderId, PlatFormId);
        }

        public Page<Trade> GetTradeList(int pageindex, int pagesize,int? UserAccountId,int State,int? IsQrcode,DateTime? BeginTime, DateTime? EndTime) {
            string sql = string.Empty;
            string wherestr = string.Empty;
            if (UserAccountId != null) {
                wherestr += " and UserAccountId =@0 ";
            }
            if (State >-1) {
                wherestr += " and State =@1 ";
            }
            if (IsQrcode != null) {
                wherestr += " and IsQrcode =@2 ";
            }
            if (BeginTime != null) {
                wherestr += " and TradeTime >=@3 ";
            }
            if (EndTime != null) {
                wherestr += " and TradeTime <@4 ";
            }
            sql = string.Format(@"
SELECT  *
FROM    dbo.Trade
WHERE 1=1 {0}
ORDER BY CreateTime DESC", wherestr);
            return CollectionDB.GetInstance().Page<Trade>(pageindex, pagesize, sql, UserAccountId, State, IsQrcode, BeginTime, EndTime?.AddDays(1));
        }
        public List<Trade> GetTradeLists(int? UserAccountId, int State, int? IsQrcode, DateTime? BeginTime, DateTime? EndTime) {
            string sql = string.Empty;
            string wherestr = string.Empty;
            if (UserAccountId != null) {
                wherestr += "and UserAccountId =@0 ";
            }
            if (State > -1) {
                wherestr += "and State =@1 ";
            }
            if (IsQrcode != null) {
                wherestr += " and IsQrcode =@2 ";
            }
            if (BeginTime != null) {
                wherestr += " and TradeTime >=@3 ";
            }
            if (EndTime != null) {
                wherestr += " and TradeTime <@4 ";
            }
            sql = string.Format(@"
SELECT  *
FROM    dbo.Trade
WHERE 1=1 {0}
", wherestr);
            return CollectionDB.GetInstance().Fetch<Trade>(sql, UserAccountId, State,IsQrcode, BeginTime, EndTime?.AddDays(1));
        }
    }
}
