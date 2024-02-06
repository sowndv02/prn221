using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net.Mail;

namespace Learning_SendMail.Service
{
    public class SendMailService
    {

        MailSetting _mailSetting { get; set; }
                
        public SendMailService(IOptions<MailSetting>mailSetting) 
        {
            _mailSetting = mailSetting.Value;
        }

        public async Task<string> SendMail(MailContent mailContent)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Mail);
            email.From.Add(new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Mail));
            email.To.Add(new MailboxAddress(mailContent.To, mailContent.To));
            email.Subject = mailContent.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = mailContent.Body;
            email.Body = builder.ToMessageBody();
            using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                await smtpClient.ConnectAsync(_mailSetting.Host, _mailSetting.Port, SecureSocketOptions.StartTls);
                await smtpClient.AuthenticateAsync(_mailSetting.Mail, _mailSetting.Password);
                await smtpClient.SendAsync(email);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error";
            }
            finally
            {
                smtpClient.Disconnect(true);
            }
            return "Successful";
        }
    }
    public class MailContent
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
