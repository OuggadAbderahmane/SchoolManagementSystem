namespace SchoolManagementSystem.Data.Responses
{
    public class GetAllStudentInfoResponse
    {
        public int Id { get; set; }
        public string NationalCardNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string? SectionName { get; set; }
        public string? classInfo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? ImagePath { get; set; }
        public bool IsAvtive { get; set; }
    }
}
