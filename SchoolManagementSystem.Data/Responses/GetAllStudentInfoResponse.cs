namespace SchoolManagementSystem.Data.Responses
{
    public class GetAllStudentInfoResponse
    {
        public int Id { get; set; }
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public enGender Gender { get; set; }
        public string? SectionName { get; set; }
        public int? GuardianId { get; set; }
        public string? GuardianFullName { get; set; }
        public string? GuardianPhone { get; set; }
        public string? ClassInfo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? ImagePath { get; set; }
        public string? GuardianImagePath { get; set; }
        public bool IsActive { get; set; }
    }
}
