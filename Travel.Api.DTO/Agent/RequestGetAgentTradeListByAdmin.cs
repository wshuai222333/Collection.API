using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.DTO.Agent {
    public class RequestGetAgentTradeListByAdmin : RequestOriBaseModel {
       

        public int State { get; set; }

        public string TradeOrderId { get; set; }

        public DateTime? BeginTime { get; set; }

        public DateTime? EndTime { get; set; }
        public int pageindex { get; set; }

        public int pagesize { get; set; }
    }
}
