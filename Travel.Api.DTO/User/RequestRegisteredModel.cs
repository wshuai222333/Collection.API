using Collection.Api.DTO;

namespace CollectionApi.DTO.User {
    /// <summary>
    /// 注册请求实体
    /// </summary>
    public class RequestRegisteredModel : RequestOriBaseModel {
        public string UserName { get; set; }

        public string UserPwd { get; set; }

        public string UserPhone { get; set; }
    }
}
