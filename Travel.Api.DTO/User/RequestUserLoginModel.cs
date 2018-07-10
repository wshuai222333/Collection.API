using Collection.Api.DTO;

namespace CollectionApi.DTO.User {
    public  class RequestUserLoginModel: RequestOriBaseModel {
        public string UserName { get; set;}

        public string UserPwd { get; set; }
    }
}
