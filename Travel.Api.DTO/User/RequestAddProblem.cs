namespace Collection.Api.DTO.User {
    public class RequestAddProblem:RequestOriBaseModel
    {
        public int ProblemId { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }
    }
}
