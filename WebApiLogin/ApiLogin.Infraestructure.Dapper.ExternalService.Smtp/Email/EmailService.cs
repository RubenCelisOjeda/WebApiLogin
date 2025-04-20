using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace ApiLogin.Infraestructure.Dapper.ExternalService.Smtp.Email
{
    public class EmailService : IEmailService
    {
        public EmailService()
        {

        }

        public async Task<bool> SendCodeEmail(string code)
        {
            bool isValid = true;

            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("sistemas.celis@gmail.com", "gmaRcelis2728$"));
                email.To.Add(new MailboxAddress("Envios", "sistemas.celis@gmail.com"));
                email.Subject = "¡MailKit es gratis!";

                email.Body = new TextPart("plain")
                {
                    Text = $"Tu código de verificación es: {code}\nVálido por 10 minutos."
                };

                using var client = new SmtpClient();
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("sistemas.celis@gmail.com", "romz jixx vfqv rkod");
                await client.SendAsync(email);
                await client.DisconnectAsync(true);
            }
            catch (Exception)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
