using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using Attachment = System.Net.Mail.Attachment;

namespace FIT5032_Week08A.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            /*var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("ygee0015@student.monash.edu", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);*/
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("yge6502@gmail.com", "geyang1996"),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress("yge6502@gmail.com"),
                Subject = subject,
                Body = contents,
                IsBodyHtml = true,
            };
            var attachment = new Attachment("C:/Users/Administrator/Desktop/随机数/2.png", MediaTypeNames.Image.Jpeg);
            mailMessage.Attachments.Add(attachment);
            mailMessage.To.Add(toEmail);

            smtpClient.Send(mailMessage);

            //smtpClient.Send("email", "recipient", "subject", "body");
        }

    }
}