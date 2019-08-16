namespace Model.Pattern
{
    public class UserInfo : IUserInfo
    {
        public UserInfo(string affiliateId, string userId)
        {
            Initialize(string.IsNullOrWhiteSpace(affiliateId) ? 0 : int.Parse(affiliateId.Split('@')[1]),
                       string.IsNullOrWhiteSpace(userId) ? 0 : int.Parse(userId));
        }

        public UserInfo(int affiliateId, int userId)
        {
            Initialize(affiliateId, userId);
        }

        private void Initialize(int affiliateId, int userId)
        {
            this.AffiliateId = affiliateId;
            this.UserId = userId;
        }

        public int AffiliateId { get; private set; }
        public int UserId { get; private set; }
    }
}
