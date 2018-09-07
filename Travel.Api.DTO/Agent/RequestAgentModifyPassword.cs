using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.DTO.Agent {
    public class RequestAgentModifyPassword : RequestOriBaseModel {
        public int AgentModifyId { get; set; }
        public string OldUserPwd { get; set; }
        public string UserPwd { get; set; }
    }
}
