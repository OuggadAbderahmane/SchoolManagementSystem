namespace SchoolManagementSystem.Data.Responses
{
    public class GetAllTeacherInfoResponse
    {
        public int Id { get; set; }
        public string NationalCardNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
        public bool PermanentWork { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? ImagePath { get; set; }
    }
}
