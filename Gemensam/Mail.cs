using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Hooker.Gemensam
{
    /// <summary>
    /// 
    /// </summary>
    public class Mail
    {

        /// <summary>
        /// Konstruktor
        /// </summary>
        public Mail()
        {
            //MailFrom = Konfiguration.GetConfigData("MailFrom").ToString();
            //Password = Konfiguration.GetConfigData("Password").ToString();

            //MailFrom = "goran.hardelin@gmail.com";
            //Password = "Yaya-gumman2017";
        }

        /// <summary>
        /// Mail from address
        /// </summary>
        public string MailFrom { get; set; }

        /// <summary>
        /// Mail from address
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Mail to address
        /// </summary>
        public string MailTo { get; set; }

        /// <summary>
        /// Mail subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Mail body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Is HTML
        /// </summary>
        public bool IsHTML { get; set; }

        /// <summary>
        /// Send mail
        /// </summary>
        public void SendMail()
        {
            try
            {
                var fromAddress = new MailAddress(MailFrom);
                var fromPassword = Password;
                var toAddress = new MailAddress(MailTo);

                string subject = Subject;
                string body = Body;

                MailMessage mail = new MailMessage(fromAddress.Address, toAddress.Address);
                SmtpClient client = new SmtpClient();

                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(fromAddress.Address, 
                    fromPassword);
                client.Host = "smtp.outlook.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                    SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = IsHTML;

                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
