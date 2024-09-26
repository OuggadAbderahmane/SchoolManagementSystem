namespace SchoolManagementSystem.Data.Responses
{
    public class GetUserResponse
    {
        public GetUserResponse()
        {

        }
        public GetUserResponse(int id, string userName, int? personId)
        {
            Id = id;
            UserName = userName;
            PersonId = personId;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public int? PersonId { get; set; }
    }
}
