namespace Collection.Api.DTO.Agent {
    public class RequestAgentList : RequestOriBaseModel {
        public int pageindex { get; set; }

        public int pagesize { get; set; }
    }
}
