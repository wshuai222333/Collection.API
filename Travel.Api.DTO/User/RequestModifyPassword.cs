namespace Collection.Api.DTO.User {
    public class RequestModifyPassword: RequestOriBaseModel {
        public string UserName { get; set;}
        public string OldUserPwd { get; set; }
        public string UserPwd { get; set; }
    }
}
