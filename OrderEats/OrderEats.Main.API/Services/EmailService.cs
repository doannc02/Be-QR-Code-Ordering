using System.Net.Mail;
using System.Net;

namespace OrderEats.Main.API.Services
{
    public static class EmailService
    {
        private static string fromEmail;
        private static string password;
        private static string smtpHost;
        private static int smtpPort;
      
        static EmailService()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            fromEmail = configuration["EmailSettings:SmtpUsername"];
            password = configuration["EmailSettings:SmtpPassword"];
            smtpHost = configuration["EmailSettings:SmtpHost"];
            smtpPort = int.Parse(configuration["EmailSettings:SmtpPort"]);
        }

        public static async Task SendEmail(string subject, string body, string toEmail)
        {
            try
            {
                if (fromEmail == null || password == null)
                    throw new InvalidOperationException("Email or password is missing from configuration");

                var fromAddress = new MailAddress(fromEmail, "Hệ Thống Nhà hàng Dev Quê Lúa");
                var toAddress = new MailAddress(toEmail);

                var smtp = new SmtpClient
                {
                    Host = smtpHost,
                    Port = smtpPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, password),
                    Timeout = 20000
                };

                using var email = new MailMessage(fromAddress, toAddress)
                {
                    IsBodyHtml = true,
                    Subject = subject,
                    Body = body
                };

                await smtp.SendMailAsync(email);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error sending email: {e.Message}");
                throw;
            }
        }
    }
}
