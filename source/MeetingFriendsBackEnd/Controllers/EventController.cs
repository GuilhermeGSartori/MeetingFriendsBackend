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
        public async Task<IActionResult> Save([FromBody] Event data)
        {
            if (data == null)
                return BadRequest();

            TAR result = await db.Save(data); //the one implemented in repo.
            if (result == null) // almost impossible to happen, but it's necessary
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("(Id)")]
        public async Task<IActionResult> GetEvent(int? Id)
        {
            if (Id == null)
                return BadRequest();

            Event result = await db.GetEvent(Id);
            if (result == null) //if for some reason the result does to returns...
                return NotFound(); //this happens the Id is null...

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            IQueryable<Event> data = db.GetEvents;

            return Ok(data);
        }
    }
}