namespace YBS.Services.Dtos.Requests
{
    public class AccountCreateRequest
    {
        public int RoleId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}