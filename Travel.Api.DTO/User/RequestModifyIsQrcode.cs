namespace Collection.Api.DTO.User {
    public class RequestModifyIsQrcode : RequestOriBaseModel {
        public int UserAccountId { get; set; }

        public int IsQrcode { get; set; }
    }
}
