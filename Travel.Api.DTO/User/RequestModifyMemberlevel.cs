namespace Collection.Api.DTO.User {
    public class RequestModifyMemberlevel: RequestOriBaseModel {
        public int UserAccountId { get; set; }

        public int Memberlevel { get; set; }
    }
}
