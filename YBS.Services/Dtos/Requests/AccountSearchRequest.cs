namespace YBS.Services.Dtos.Requests
{
    public class AccountSearchRequest : PageRequest
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}