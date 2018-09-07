using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.DTO.User {
    public class RequestModifyRate : RequestOriBaseModel {
        public int UserAccountId { get; set; }

        public decimal UserRate { get; set; }
    }
}
