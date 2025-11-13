namespace Jobseer.Application.Features.User.Commands.Login
{
    public class LoginResponse
    {
        public string Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
