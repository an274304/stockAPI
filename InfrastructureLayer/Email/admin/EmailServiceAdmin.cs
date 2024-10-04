using ApplicationLayer.IServices.Admin.Email;
using DomainLayer.V1.DTOs;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Email.admin
{
    public class EmailServiceAdmin : IEmailServiceAdmin
    {
        private readonly SmtpSetting _smtpSetting;
        public EmailServiceAdmin(IOptions<SmtpSetting> smtpSetting) {
            _smtpSetting = smtpSetting.Value;
        }

        public void SendEmail()
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_smtpSetting.AppName, _smtpSetting.From));
            emailMessage.To.Add(new MailboxAddress("", "edp@committedcargo.com")); // Empty string for display name
            emailMessage.Subject = "Test Email";
            emailMessage.Body = new TextPart("html") { Text = "Hello" };

            using (var client = new SmtpClient())
            {
                client.Connect(_smtpSetting.SmtpServer, _smtpSetting.Port, MailKit.Security.SecureSocketOptions.SslOnConnect);
                client.Authenticate(_smtpSetting.UserName, _smtpSetting.Password);
                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}
