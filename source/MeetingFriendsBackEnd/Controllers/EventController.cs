using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App.Services;
using App.Data;
using MimeKit;
using MailKit.Net.Smtp;

namespace MeetingFriendsBackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Event")]
    public class EventController : Controller
    {
        private readonly IEvent db;
        private readonly ILogin login_db;
        private readonly IUser user_db;

        public EventController(IEvent _db, ILogin _login_db, IUser _user_db)
        {
            db = _db;
            login_db = _login_db;
            user_db = _user_db;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Event data)
        {
            if (data == null)
                return BadRequest();

            User login = await login_db.GetLogin();
            if (login == null)
                return BadRequest();

            TAR resultEvent = await db.Save(data); //the one implemented in EventRepo
            if (resultEvent == null) // almost impossible to happen, but it's necessary
            {
                return NotFound();
            }

            /* EMAIL SENDING SECTION -> NEXT RELEASE!
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Admin", login.Email);
            message.From.Add(from);

            BodyBuilder bodyBuilder = new BodyBuilder()
            {
                HtmlBody = "<h1>Hello World!</h1>",
                TextBody = "Hello World!"
            };
            message.Body = bodyBuilder.ToMessageBody();

            foreach (User user in user_db.GetUsers)
            {
                if (user.UserId != login.UserId)
                {
                    MailboxAddress to = new MailboxAddress("User", user.Email);
                    message.To.Add(to);

                    message.Subject = "Convite para Evento: " + data.EventName;

                    //using (var emailClient = new SmtpClient())
                    //{
                    //The last parameter here is to use SSL (Which you should!)
                    //emailClient.Connect("smtp.gmail.com", 587, true);

                    //Remove any OAuth functionality as we won't be using it. 
                    //emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                    //emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);

                    //emailClient.Send(message);

                    //emailClient.Disconnect(true);
                    //}
                }
            }*/

            return Ok(resultEvent);
        }

        [HttpGet("(Id)")]
        public async Task<IActionResult> GetEvent(int? Id)
        {
            if (Id == null)
                return BadRequest();

            Event result = await db.GetEvent(Id);

            if (result == null) //Event of "Id" not found!
                return NotFound(); 

            return Ok(result);
        }

        //GET api/Event
        [HttpGet]
        public IActionResult GetEvents()
        {
            IQueryable<Event> data = db.GetEvents;

            return Ok(data);
        }
    }
}