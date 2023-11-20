using BootRent.DAL.Response;


namespace BootRent.BL.Services.MailingService
{
    public interface IMailingService
    {
        Task<UserManagerResponse> SendEmail(string email, int? OTP);

    }
}
