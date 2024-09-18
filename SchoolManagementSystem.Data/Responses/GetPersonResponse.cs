namespace SchoolManagementSystem.Data.Responses
{
    public class GetPersonResponse
    {
        public int Id { get; set; }
        public string NationalCardNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string? ImagePath { get; set; }
    }
}
