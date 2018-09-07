using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.DTO.Agent {
    public class RequestAgentLogin : RequestOriBaseModel {
        public int AngetLoginId{ get; set; }

        public string UserName { get; set; }

        public string UserPwd { get; set; }
    }
}
