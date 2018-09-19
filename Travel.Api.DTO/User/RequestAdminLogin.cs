using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.DTO.User {
    public class RequestAdminLogin : RequestOriBaseModel {
        public string UserName { get; set; }

        public string UserPwd { get; set; }
    }
}
