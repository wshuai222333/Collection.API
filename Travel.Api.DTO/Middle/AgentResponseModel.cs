using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.DTO.Middle
{
    public class AgentResponseModel
    {
        public string RespCode { get; set; }

        public string RespDesc { get; set; }

        public string PlatformId { get; set; }

        public string OrderId { get; set; }

        public string TransAmt { get; set; }

        public string MerPriv { get; set; }

        public string Extension { get; set; }
    }
}
