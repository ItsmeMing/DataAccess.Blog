namespace DataAccess.Blog.DataRequests
{
    public class UserLoginRequestData
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    
    public class UserUpdateRefeshTokenRequestData
    {
        public int id { get; set; }
        public string refresh_token { get; set; }

        public DateTime refresh_token_expired_date { get; set; }
    }
}