namespace Collection.Api.DTO.User {
    public class RequestModifyIsQrcode : RequestOriBaseModel {
        public int UserAccountId { get; set; }

        public int IsQrcode { get; set; }

        public decimal Rate { get; set; }

        public decimal DrawFee { get; set; }
    }
}
