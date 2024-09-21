namespace SchoolManagementSystem.Data.Responses
{
    public class GetUserRolesResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public List<Roles> Roles { get; set; } = [];
    }

    public class Roles
    {
        public string Name { get; set; }
        public bool HasIt { get; set; }
    }
}
