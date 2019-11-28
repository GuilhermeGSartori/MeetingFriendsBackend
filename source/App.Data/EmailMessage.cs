using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data
{
    public class EmailMessage
    {
        public string ToAddress { get; }

        public EmailMessage(string _ToAddress)
        {
            ToAddress = _ToAddress;
        }
        public string Subject { get; set; }
        public BodyBuilder Content { get; set; }
    }
}
