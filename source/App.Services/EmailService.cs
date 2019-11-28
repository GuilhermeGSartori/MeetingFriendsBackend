using System;
using System.Collections.Generic;
using System.Text;
using App.Data;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace App.Services
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
    }

    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public void Send(EmailMessage emailMessage)
        {
            var message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("MeetingFriends", _emailConfiguration.SmtpUsername); //Email: Sender
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("User", emailMessage.ToAddress);//Email: Reciever 
            message.To.Add(to);

            message.Subject = emailMessage.Subject;
            message.Body = emailMessage.Content.ToMessageBody();

            using (var emailClient = new SmtpClient())
            {
                //Mailkit handles with the TLS
                //Connects to the smtp server (the server which will send the email)
                emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, SecureSocketOptions.StartTls);

                //Remove any OAuth functionality as we won't be using it. 
                // emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                //Login to gmail account
                emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);

                emailClient.Send(message);

                emailClient.Disconnect(true);
            }
        }
    }
}
