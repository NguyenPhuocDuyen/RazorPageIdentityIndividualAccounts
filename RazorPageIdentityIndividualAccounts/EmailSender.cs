using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RazorPageIdentityIndividualAccounts
{
    public class EmailSender : IEmailSender
    {
        public string SendGridSecret { get; set; }
        public EmailSender(IConfiguration _config)
        {
            SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(SendGridSecret);
            var from = new EmailAddress("nickbaovelienminh@gmail.com", "cmcjdcjwanebotbc");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
            return client.SendEmailAsync(msg);
        }

    }
}
