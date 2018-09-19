namespace Collection.Api.DTO.Trade {
    public class RequestAddTrade : RequestOriBaseModel {
        public string TradeOrderId { get; set; }

        public decimal Amount { get; set; }

        public string CardId { get; set; }

        public string MobileNo { get; set; }

        public string BankName { get; set; }

        public string BankNum { get; set; }

        public string AcctCardNo { get; set; }

        public string AcctName { get; set; }

        public string AcctIdCard { get; set; }

        public decimal TradeRate { get; set; }

        public string TradeRateCode { get; set; }

        public int UserAccountId { get; set; }

        public int IsQrcode { get; set; }

        public decimal Rate { get; set; }

        public decimal DrawFee { get; set; }

        public decimal UserDrawFee { get; set; } 
    }
}
