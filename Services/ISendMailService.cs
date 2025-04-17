using System.Net.Mail;
using System.Net;
using MyWebApi.ViewModel;

namespace MyWebApi.Service
{
    public interface ISendMailService
    {
        Task<bool> SendEmail(EmailModel emailModel);
    }
    public class SendEmailService : ISendMailService
    {
        private readonly IConfiguration _configuration;

        public SendEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmail(EmailModel emailModel)
        {
            try
            {
                var host = _configuration["Gmail:Host"];
                var port = int.Parse(_configuration["Gmail:Port"]);
                var username = _configuration["Gmail:Username"];
                var password = _configuration["Gmail:Password"];

                using (var client = new SmtpClient(host, port))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(username, password);
                    client.EnableSsl = true;
                    var mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(username);
                    mailMessage.To.Add(new MailAddress(emailModel.ToEmail));
                    mailMessage.Subject = emailModel.Subject;
                    mailMessage.Body = emailModel.Body;
                    mailMessage.IsBodyHtml = true;
                    await client.SendMailAsync(mailMessage);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
