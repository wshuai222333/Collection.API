using Collection.Entity.CollectionModel;
using PetaPoco.NetCore;
using System;
using System.Collections.Generic;

namespace Collection.PetaPoco.Repositories.Collection {
    public class AgentTradeRep {
        public object Insert(AgentTrade model) {
            return CollectionDB.GetInstance().Insert(model);
        }
        public int UpdateState(int State, string OrderId, string PlatFormId) {
            string sql = "set State=@0,PlatFormId=@2,TradeTime=getdate() where [TradeOrderId]=@1";
            return CollectionDB.GetInstance().Update<AgentTrade>(sql, State, OrderId, PlatFormId);
        }
        public AgentTrade GetAgentTrade(AgentTrade model) {
            #region sql
            string wherestr = string.Empty;
            if (!string.IsNullOrWhiteSpace(model.TradeOrderId)) {
                wherestr += " AND TradeOrderId = @0 ";
            }
            if (!string.IsNullOrWhiteSpace(model.OrderId)) {
                wherestr += " AND OrderId = @1 ";
            }
            if (model.AgentId>0) {
                wherestr += " AND AgentId = @2 ";
            }
            string sql = string.Format(@"
SELECT  *
FROM    [dbo].[AgentTrade]
WHERE   1 = 1
        {0} ", wherestr);
            #endregion
            var agentTrade = CollectionDB.GetInstance().FirstOrDefault<AgentTrade>(sql,
                model.TradeOrderId, model.OrderId, model.AgentId);
            return agentTrade;
        }
        public Page<AgentTrade> GetAgentTradeList(int pageindex, int pagesize, int? AgentId, int State,string TradeOrderId,DateTime? BeginTime,DateTime? EndTime) {
            string sql = string.Empty;
            string wherestr = string.Empty;
            if (AgentId != null) {
                wherestr += " and AgentId =@0 ";
            }
            if (State > -1) {
                wherestr += " and State =@1 ";
            }
            if (!string.IsNullOrWhiteSpace(TradeOrderId)) {
                wherestr += " and TradeOrderId =@2 ";
            }
            if (BeginTime != null) {
                wherestr += " and TradeTime >=@3 ";
            }
            if (EndTime != null) {
                wherestr += " and TradeTime <@4 ";
            }
            sql = string.Format(@"
SELECT  *
FROM    dbo.AgentTrade
WHERE 1=1 {0}
ORDER BY CreateTime DESC", wherestr);
            return CollectionDB.GetInstance().Page<AgentTrade>(pageindex, pagesize, sql, AgentId, State, TradeOrderId, BeginTime, EndTime);
        }
        public List<AgentTrade> GetAgentTradeLists(int AgentId, int State, string TradeOrderId, DateTime? BeginTime, DateTime? EndTime) {
            string sql = string.Empty;
            string wherestr = string.Empty;
            if (AgentId > 0) {
                wherestr += " and AgentId =@0 ";
            }
            if (State > -1) {
                wherestr += " and State =@1 ";
            }
            if (!string.IsNullOrWhiteSpace(TradeOrderId)) {
                wherestr += " and TradeOrderId =@2 ";
            }
            if (BeginTime != null) {
                wherestr += " and TradeTime >=@3 ";
            }
            if (EndTime != null) {
                wherestr += " and TradeTime <@4 ";
            }
            sql = string.Format(@"
SELECT  *
FROM    dbo.AgentTrade
WHERE 1=1 {0}
ORDER BY CreateTime DESC", wherestr);
            return CollectionDB.GetInstance().Fetch<AgentTrade>(sql, AgentId, State, TradeOrderId, BeginTime, EndTime);
        }
    }
}
