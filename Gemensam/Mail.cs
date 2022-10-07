using System;
using System.Net;
using System.Net.Mail;

namespace Hooker.Gemensam
{
    /// <summary>
    /// 
    /// </summary>
    public class Mail
    {
        /// <summary>
        /// Skicka mail
        /// <paramref name="Mailet">Det mail som ska skickas</paramref>/>
        /// </summary>
        public void Skicka_Mail(Hooker.Affärsobjekt.Mail Mailet)
        {
            try
            {
                var fromAddress = new MailAddress(Mailet.MailFrom);
                var fromPassword = Mailet.Password;
                var toAddress = new MailAddress(Mailet.MailTo);

                string subject = Mailet.Subject;
                string body = Mailet.Body;

                MailMessage mailMessage = new MailMessage(fromAddress.Address,
                    toAddress.Address);

                SmtpClient client = new SmtpClient
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address,
                        fromPassword),
                    Host = Mailet.SmtpHost,
                    Port = Mailet.Port,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                    SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = Mailet.IsHTML;

                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
