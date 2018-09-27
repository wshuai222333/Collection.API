namespace Collection.Api.DTO.Agent {
    public class RequestAgentModifyState : RequestOriBaseModel {
        public int AgentModifyId { get; set; }
        public int State { get; set; }
    }
}
