﻿namespace Collection.Api.DTO.Trade {
    public class RequestGetTradeList:RequestOriBaseModel {
        public int? UserAccountId { get; set; }

        public int pageindex { get; set; }

        public int pagesize { get; set; }
    }
}