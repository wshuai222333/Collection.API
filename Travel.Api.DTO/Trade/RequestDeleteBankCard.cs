using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.DTO.Trade
{
    public class RequestDeleteBankCard : RequestOriBaseModel {
        public int BankCardId { get; set; }
    }
}
