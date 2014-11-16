using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace CompanyABC.Core.Email
{
    public interface IEmailSender : IDisposable
    {
        void SendMessages(IEnumerable<MailMessage> mailMessages);
    }
}