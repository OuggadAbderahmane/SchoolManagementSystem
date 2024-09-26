namespace SchoolManagementSystem.Data.Responses
{
    public class GetUserClaimsResponse
    {
        public int UserId { get; set; }
        public List<UserClaim> Claims { get; set; } = [];
    }

    public class UserClaim
    {
        public string Type { get; set; }
        public bool Value { get; set; }
    }
}
