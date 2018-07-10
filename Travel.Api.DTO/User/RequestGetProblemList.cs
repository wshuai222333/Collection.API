using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.DTO.User
{
    public class RequestGetProblemList : RequestOriBaseModel {
        public string Title { get; set; }

        public int pageindex { get; set; }

        public int pagesize { get; set; }
    }
}
