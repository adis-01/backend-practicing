using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services.Helpers
{
    public class EmailSender
    {
        
        
        public static string SendEmail(string verificationToken,string emailAddress,string name)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse("go.donate2fa@gmail.com"));
            message.To.Add(MailboxAddress.Parse(emailAddress));
            message.Subject = "Email verification token - please verify";
            message.Body = new TextPart(TextFormat.Plain)
            {
                Text = $"Hi, {name}"
            };
            using var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            client.Authenticate("go.donate2fa@gmail.com", "dqgijmajcpgukcyy");
            client.Send(message);
            client.Disconnect(true);
            
            return "Email sent";
        }
    }
}
