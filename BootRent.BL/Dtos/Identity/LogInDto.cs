namespace BootRent.BL.Dtos.Identity
{
    public class LogInDto
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
