using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.DTO.Trade
{
    public class RequestTradePay : RequestOriBaseModel {
      
        public string Subject { get; set; }
      
        public string TransAmt { get; set; }
      
        public string CardId { get; set; }

        public string MobileNo { get; set; }

        public string AcctName { get; set; }

        public string AcctIdcard { get; set; }

        public string BankNum { get; set; }

        public string AcctCardno { get; set; }

        public string RetUrl { get; set; }

        public string BgRetUrl { get; set; }

        public string MerPriv { get; set; }
        public string Extension { get; set; }
        public string OrderId { get; set; }
    }
}
