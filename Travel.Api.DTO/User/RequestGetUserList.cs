using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.DTO.User
{
    public class RequestGetUserList : RequestOriBaseModel {
        public string UserName { get; set; }

        public string Phone { get; set; }

        public int? UserAccountId { get; set; }
        public int pageindex { get; set; }

        public int pagesize { get; set; }
    }
}
