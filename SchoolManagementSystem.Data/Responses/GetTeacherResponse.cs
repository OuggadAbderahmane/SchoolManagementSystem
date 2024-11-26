namespace SchoolManagementSystem.Data.Responses
{
    public class GetTeacherResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool PermanentWork { get; set; }
        public string? ImagePath { get; set; }
    }
}
