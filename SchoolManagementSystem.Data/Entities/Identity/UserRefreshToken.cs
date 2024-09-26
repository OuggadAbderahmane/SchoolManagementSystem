namespace SchoolManagementSystem.Data.Entities.Identity
{
    public class UserRefreshToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RefreshTokenString { get; set; }
        public DateTime ExpireAt { get; set; }
        public User User { get; set; }

        public UserRefreshToken() { }

        public UserRefreshToken(int userId, string refreshTokenString, DateTime expireAt)
        {
            UserId = userId;
            RefreshTokenString = refreshTokenString;
            ExpireAt = expireAt;
        }

    }
}
