using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.DTO.Trade
{
    public class RequestAddBankCard : RequestOriBaseModel {
        public int UserAccountId { get; set; }

        public string CardId { get; set; }

        public string BankName { get; set; }

        public string BankCode { get; set; }

        public string Phone { get; set; }

        public string AcctName { get; set; }

        public int Type { get; set; }
    }
}
