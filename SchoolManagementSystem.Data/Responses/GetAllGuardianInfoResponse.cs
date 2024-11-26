namespace SchoolManagementSystem.Data.Responses
{
    public class GetAllGuardianInfoResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public enGender Gender { get; set; }
        public string JobName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? ImagePath { get; set; }
    }
}
