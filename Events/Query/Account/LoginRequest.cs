namespace WebApi.Events.Query.Account
{
    public class LoginRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}