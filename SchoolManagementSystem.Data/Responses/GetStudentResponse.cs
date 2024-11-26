namespace SchoolManagementSystem.Data.Responses
{
    public class GetStudentResponse
    {
        public int Id { get; set; }
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? SectionName { get; set; }
        public string? classInfo { get; set; }
        public enGender Gender { get; set; }
        public string? ImagePath { get; set; }
    }
}
