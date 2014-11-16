using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace CompanyABC.Core.Email
{
    public class SystemEmailSender : IEmailSender
    {
        SmtpClient Client { get; set; }
        public SystemEmailSender()
        {
            Client = new SmtpClient();
        }

        public void Dispose()
        {
            if (Client != null)
            {
                Client.Dispose();
                Client = null;
            }
        }

        public void SendMessages(IEnumerable<MailMessage> mailMessages)
        {
            foreach (MailMessage mailMessage in mailMessages)
            {
                Client.Send(mailMessage);
            }
        }
    }
}