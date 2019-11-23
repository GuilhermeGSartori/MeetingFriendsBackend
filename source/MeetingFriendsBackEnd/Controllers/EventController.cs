using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App.Services;
using App.Data;

namespace MeetingFriendsBackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Event")]
    public class EventController : Controller
    {
        private readonly IEvent db;

        public EventController(IEvent _db)
        {
            db = _db;
        }

        [HttpPost]
        public IActionResult Save([FromBody] Event data)
        {
            if (data == null)
                return BadRequest();

            db.Save(data); //the one implemented in repo.

            return Ok(data);
        }

        [HttpGet("(Id)")]
        public IActionResult GetEvent(int? Id)
        {
            Event data = db.GetEvent(Id);

            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            IQueryable<Event> data = db.GetEvents;

            return Ok(data);
        }
    }
}