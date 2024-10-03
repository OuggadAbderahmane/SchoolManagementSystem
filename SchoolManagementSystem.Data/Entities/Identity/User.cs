using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Data.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public override string UserName { get; set; }
        public override string PasswordHash { get; set; }
        public int? PersonId { get; set; }
        public Person? Person { get; set; }

        public UserRefreshToken UserRefreshToken { get; set; }
        public ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
