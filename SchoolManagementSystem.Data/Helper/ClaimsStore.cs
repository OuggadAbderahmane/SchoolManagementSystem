using System.Security.Claims;

namespace SchoolManagementSystem.Data.Helper
{
    public static class ClaimsStore
    {
        public static List<Claim> claims = [
            new Claim("Student","fales"),
            new Claim("Teacher","fales"),
            new Claim("Guardian","fales")
            ];
    }
}
