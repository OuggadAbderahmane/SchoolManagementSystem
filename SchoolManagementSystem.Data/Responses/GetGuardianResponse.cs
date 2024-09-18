namespace SchoolManagementSystem.Data.Responses
{
    public class GetGuardianResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobName { get; set; }
        public string? ImagePath { get; set; }
    }
}
