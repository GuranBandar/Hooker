using Hooker.Affärsobjekt;
using System;
using System.Net;
using System.Net.Mail;

namespace Hooker.Gemensam
{
    /// <summary>
    /// 
    /// </summary>
    public class Maila
    {
        /// <summary>
        /// Send mail
        /// <paramref name="Mail"/>
        /// </summary>
        public void SendMail(Mail Mail)
        {
            try
            {
                var fromAddress = new MailAddress(Mail.MailFrom);
                var fromPassword = Mail.Password;
                var toAddress = new MailAddress(Mail.MailTo);

                string subject = Mail.Subject;
                string body = Mail.Body;

                MailMessage mailMessage = new MailMessage(fromAddress.Address, toAddress.Address);

                SmtpClient client = new SmtpClient
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address,
                        fromPassword),
                    Host = Mail.SmtpHost,
                    Port = Mail.Port,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                    SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = Mail.IsHTML;

                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
