using System.Net;
using System.Net.Mail;

namespace Learning_SendMail.MailUtils
{
    public class MailUtils
    {
        // Sử dụng SmtpClient
        public static async Task<string> SendMail(string from, string to, string subject, string body)
        {
            MailMessage message = new MailMessage(from, to, subject, body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            message.ReplyToList.Add(new MailAddress(from));
            message.Sender = new MailAddress(from);


            using (var smtpClient = new SmtpClient("localhost"))
            {
                try
                {
                    await smtpClient.SendMailAsync(message);
                    return "successful";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return "Failed";
                }
            }
        }


        // Sử dụng cổng Google
        public static async Task<string> SendGmail(string from, string to, string subject, string body, string email, string password)
        {
            MailMessage message = new MailMessage(from, to, subject, body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            message.ReplyToList.Add(new MailAddress(from));
            message.Sender = new MailAddress(from);


            using (var smtpClient = new SmtpClient("smtp.gamil.com"))
            {
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(email, password);
                try
                {
                    await smtpClient.SendMailAsync(message);
                    return "successful";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return "Failed";
                }
            }
        }


        // Sử dụng MailKit
        // dotnet add package MailKit
        // dotnet add package MimeKit

    }
}
