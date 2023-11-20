using BootRent.DAL.Response;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System.Net;
using System.Net.Mail;




namespace BootRent.BL.Services.MailingService
{
    public class MailingService : IMailingService
    {
        private readonly MailingSettings mailingSettings;
        private readonly ILogger<MailingService> logger;

        public MailingService(IOptions<MailingSettings> _mailingSettings, ILogger<MailingService> logger)
        {
            this.mailingSettings = _mailingSettings.Value;
            this.logger = logger;
        }

        public async Task<UserManagerResponse> SendEmail(string email, int? OTP)
        {
            try
            {

                MailMessage message = new MailMessage()
                {
                    From = new MailAddress(mailingSettings.Email),
                    Body = $"<html><body>please use this code  {OTP}  to validate your email </body></html>",
                    Subject = "email validation",
                    IsBodyHtml = true
                };
                message.To.Add(email);

                var smtpClient = new System.Net.Mail.SmtpClient(mailingSettings.Host)
                {
                    Port = mailingSettings.Port,
                    Credentials = new NetworkCredential(mailingSettings.Email, mailingSettings.Password),
                    EnableSsl = mailingSettings.EnableSsl,
                };



                await smtpClient.SendMailAsync(message);
                return new UserManagerResponse
                {
                    Message = "Email Send Successfully , Please Check Your Mails!",
                    IsSuccess = true,
                };

            }

            catch (SmtpException smtpEx)
            {
                logger.LogError($"Error sending email to {email}: {smtpEx}");
                logger.LogError($"StatusCode: {smtpEx.StatusCode}");
                logger.LogError($"InnerException: {smtpEx.InnerException}");
                logger.LogError($"StackTrace: {smtpEx.StackTrace}");

                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = $"SMTP Exception: {smtpEx.Message}"
                };
            }


        }
    }
}
