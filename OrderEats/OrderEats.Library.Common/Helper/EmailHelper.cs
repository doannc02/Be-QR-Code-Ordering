using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Common.Helper
{
   public class EmailHelper
    {
        public static void SendMail(string subject, string body, string toEmail, string receiver)
        {
            var fromAddress = new MailAddress("sillver47108@gmail.com", "DevQueLua");
            var toAddress = new MailAddress(toEmail, receiver);
            const string fromPassword = ""; // Mật khẩu ứng dụng https://myaccount.google.com/security

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };

            using var message = new MailMessage(fromAddress, toAddress)
            {
                IsBodyHtml = true,
                Subject = subject,
                Body = body
            };

            smtp.Send(message);
        }
    }
}
