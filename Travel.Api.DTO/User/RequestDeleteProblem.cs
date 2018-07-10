using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.DTO.User
{
    public class RequestDeleteProblem : RequestOriBaseModel {
        public int ProblemId { get; set; }
    }
}
