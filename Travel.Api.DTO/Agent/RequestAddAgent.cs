namespace Collection.Api.DTO.Agent {
    public class RequestAddAgent : RequestOriBaseModel {
        public string MerchantName { get; set; }

        public decimal Rate { get; set; }

        public string Phone { get; set; }

        public int AddAgentId { get; set; }
    }
}
