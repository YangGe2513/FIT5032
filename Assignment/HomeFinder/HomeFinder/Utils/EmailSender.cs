using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace HomeFinder.Utils
{
    public class EmailSender
    {
        public void Send(String toEmail, String subject, String contents)
        {
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
            //var attachment = new Attachment("C:/Users/Administrator/Desktop/随机数/2.png", MediaTypeNames.Image.Jpeg);
            //mailMessage.Attachments.Add(attachment);
            mailMessage.To.Add(toEmail);

            smtpClient.Send(mailMessage);

        }

    }
}