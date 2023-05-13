using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Infrastructure.Repositories
{
    public class EmailRepository
    {
        public void SendEmailMessage(string toEmail, string subject, string body)
        {
            MailAddress fromAdress = new MailAddress("health.company.dyplom@gmail.com", "Health");
            MailAddress toAdress = new MailAddress(toEmail, "Health");
            MailMessage message = new MailMessage(fromAdress, toAdress);
            message.Body = body;
            message.Subject = subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(fromAdress.Address, "xbepzdxbmmuuuohr");
            smtpClient.Send(message);
        }
    }
}
