using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Data.Entities.Identity
{
    public class Role : IdentityRole<int>
    {
        public override string Name { get => base.Name!; set => base.Name = value; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
