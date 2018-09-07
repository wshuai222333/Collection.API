using System;

namespace Collection.Api.DTO.Agent {
    public class RequestGetAgentTradeList : RequestOriBaseModel {

        public int AgentTradeId { get; set; }

        public int State { get; set; }

        public string TradeOrderId { get; set; }

        public DateTime? BeginTime { get; set; }

        public DateTime? EndTime { get; set; }
        public int pageindex { get; set; }

        public int pagesize { get; set; }
    }
}
