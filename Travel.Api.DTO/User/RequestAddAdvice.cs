namespace Collection.Api.DTO.User {
    public class RequestAddAdvice : RequestOriBaseModel {
        public int UserAccountId { get; set; }

        public string AdviceContent { get; set; }
    }
}
