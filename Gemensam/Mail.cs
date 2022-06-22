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

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 10000,
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = IsHTML
                })

                smtp.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
